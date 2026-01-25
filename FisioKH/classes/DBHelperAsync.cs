using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;

namespace FisioKH
{
    public class DBHelperAsync : IDisposable
    {
        private string connectionString;
        private bool disposed = false;

        public DBHelperAsync()
        {
            connectionString = configSettings.ObtenConectionString;
        }

        #region User Authentication

        public async Task<Usuario> AutenticarUsuarioAsync(string usuario, string pass)
        {
            Usuario usr = new Usuario();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT * FROM usuarios WHERE (nombre = @usuario AND password = @pass) OR (nombre = @usuario AND pin = @pass)",
                conn))
            {
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@pass", pass);

                await conn.OpenAsync();
                using (SqlDataReader rd = await cmd.ExecuteReaderAsync())
                {
                    if (rd.HasRows)
                    {
                        while (await rd.ReadAsync())
                        {
                            usr.Id = Convert.ToInt32(rd["id"]);
                            usr.Nombre = rd["nombre"].ToString();
                            usr.Nivel = Convert.ToInt32(rd["nivel"]);
                            usr.Activo = Convert.ToBoolean(rd["activo"]);
                            usr.FechaRegistro = rd["fechaRegistro"].ToString();
                            usr.Autenticado = true;
                        }
                    }
                    else
                    {
                        usr.Autenticado = false;
                        usr.ErrorLogin = "Credenciales inválidas!";
                    }
                }
            }

            return usr;
        }

        #endregion

        #region Data Retrieval

        public async Task<DataTable> ObtenerDatosAsync(string spName, Dictionary<string, object> spPars)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(spName, conn))
            {
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                if (spPars != null)
                    foreach (var par in spPars)
                        adapter.SelectCommand.Parameters.AddWithValue(par.Key, par.Value ?? DBNull.Value);

                await Task.Run(() => adapter.Fill(dt)); // run sync fill in background thread
            }

            return dt;
        }

        public async Task<DataTable> ObtenerDatosAsync(string sql)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
            {
                await Task.Run(() => adapter.Fill(dt));
            }

            return dt;
        }

        #endregion

        #region Non-Query Execution

        public async Task<int> EjecutarNonQueryAsync(string spName, Dictionary<string, object> spPars)
        {
            int rowsAffected = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(spName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                if (spPars != null)
                    foreach (var par in spPars)
                        cmd.Parameters.AddWithValue(par.Key, par.Value ?? DBNull.Value);

                SqlParameter outParam = new SqlParameter("@rowsAffected", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outParam);

                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();

                if (outParam.Value != DBNull.Value)
                    rowsAffected = (int)outParam.Value;
            }

            return rowsAffected;
        }

        public async Task<string> EjecutaSqlNonQueryAsync(string sql)
        {
            string result = string.Empty;

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    await conn.OpenAsync();
                    int rows = await cmd.ExecuteNonQueryAsync();
                    result = rows.ToString();
                }
                catch (Exception ex)
                {
                    result = "Error: " + ex.Message;
                }
            }

            return result;
        }

        #endregion

        #region Image Retrieval (RAM Efficient)

        public async Task<Bitmap> GetImageFromFieldAsync(DataRow row, string columnName)
        {
            if (row == null) return null;

            byte[] fotoBytes = row.Field<byte[]>(columnName);
            if (fotoBytes == null || fotoBytes.Length == 0) return null;

            try
            {
                using (MemoryStream ms = new MemoryStream(fotoBytes))
                {
                    return await Task.Run(() => new Bitmap(ms));
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// SequentialAccess for large blobs
        /// </summary>
        public async Task<Bitmap> GetImageFromDatabaseAsync(string tableName, string columnName, string whereClause)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand($"SELECT {columnName} FROM {tableName} WHERE {whereClause}", conn))
            {
                await conn.OpenAsync();
                using (SqlDataReader rd = await cmd.ExecuteReaderAsync(CommandBehavior.SequentialAccess))
                {
                    if (await rd.ReadAsync() && !await rd.IsDBNullAsync(0))
                    {
                        using (var ms = new MemoryStream())
                        {
                            byte[] buffer = new byte[8192];
                            long bytesRead, fieldOffset = 0;
                            while ((bytesRead = rd.GetBytes(0, fieldOffset, buffer, 0, buffer.Length)) > 0)
                            {
                                ms.Write(buffer, 0, (int)bytesRead);
                                fieldOffset += bytesRead;
                            }
                            ms.Position = 0;
                            return new Bitmap(ms);
                        }
                    }
                }
            }
            return null;
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                // all resources are already disposed per-method
                disposed = true;
            }
        }

        ~DBHelperAsync()
        {
            Dispose(false);
        }

        #endregion
    }
}
