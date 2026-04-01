using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace FisioKH
{
    public class DBHelper : IDisposable
    {
        private readonly string connectionString;
        private bool disposed = false;

        public DBHelper()
        {
            connectionString = configSettings.ObtenConectionString;
        }

        public DataTable obtenerTratamientos()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT   [id] ,[nombre]  FROM [dbo].[tipoTratamiento] ORDER  BY nombre ";
            dt = ObtenerDatosDT(sql);


            return dt;
        }
        public DataTable obtenerPrecios()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT [id],CONCAT([nombre],' - ',[precio]) AS nombre,[pacientePaga],[precio] FROM [dbo].[precios] WHERE activo = 1 ORDER BY nombre";
            dt = ObtenerDatosDT(sql);


            return dt;
        }
        
        public DataTable obtenerMetodosPago()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT [id],[nombre],[ocupaReferenciaPago]  FROM [dbo].[metodoPago] ORDER BY id";
            dt = ObtenerDatosDT(sql);

            return dt;
        }
        
        public DataTable obtenerFisios()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT [id],[nombreCorto] AS nombre,nombreCorto FROM [dbo].[fisioTerapeutas] WHERE activo = 1  ORDER BY nombre";
            dt = ObtenerDatosDT(sql);


            return dt;
        } 
        
        public DataTable dbObtenerSaldoPaciente(long IdPaciente,int todosSaldos)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();


            var parameters = new Dictionary<string, object>
            {
                { "@idPaciente", IdPaciente},
                { "@esAdmin",  (Program.UsuarioLogeado.Nivel ==1)?1:0 },
         
            };

            ds = ObtenerDatos("usp_obtenSaldoPaciente", "saldoPaciente", parameters);

            dt = ds.Tables["saldoPaciente"];

            return dt;
        }
        public DataTable obtenVisitasPagadasConSaldo(long idVisita,long idPaciente)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();


            var parameters = new Dictionary<string, object>
            {
                { "@idVisita", idVisita},         
                { "@idPaciente", idPaciente},         
            };

            ds = ObtenerDatos("usp_obtenVisitasPagadasConSaldo", "visitasPagadasSaldo", parameters);

            dt = ds.Tables["visitasPagadasSaldo"];

            return dt;
        }

        /// <summary>
        /// Authenticate user by username and password/pin
        /// </summary>
        public Usuario AutenticarUsuario(string usuario, string pass)
        {
            Usuario usr = new Usuario();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM usuarios WHERE (nombre = @usuario AND password = @pass) OR (nombre = @usuario AND pin = @pass)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@pass", pass);
                        cmd.CommandTimeout = 5;

                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            if (rd.HasRows)
                            {
                                while (rd.Read())
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
                }
                catch (Exception ex)
                {
                    usr.ErrorLogin = "Error: " + ex.Message;
                }
            }

            return usr;
        }

        /// <summary>
        /// Executes a stored procedure and returns a DataSet
        /// </summary>
        public DataSet ObtenerDatos(string spName, string dsname, Dictionary<string, object> spPars)
        {
            DataSet ds = new DataSet();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(spName, conn))
                    {
                        adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                        if (spPars != null)
                        {
                            foreach (var par in spPars)
                                adapter.SelectCommand.Parameters.AddWithValue(par.Key, par.Value ?? DBNull.Value);
                        }

                        adapter.Fill(ds, dsname);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener datos: " + ex.Message);
                }
            }

            return ds;
        }

        /// <summary>
        /// Executes a raw SQL query and returns a DataSet
        /// </summary>
        public DataSet ObtenerDatos(string sql, string dsname)
        {
            DataSet ds = new DataSet();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
                    {
                        adapter.Fill(ds, dsname);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener datos: " + ex.Message);
                }
            }

            return ds;
        }  
        
        /// <summary>
        /// Executes a raw SQL query and returns a DataSet
        /// </summary>
        private DataTable ObtenerDatosDT(string sql)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
                    {
                        adapter.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener datos: " + ex.Message);
                }
            }

            return dt;
        }

        /// <summary>
        /// Executes a stored procedure for non-query (insert/update/delete)
        /// Returns the output parameter @rowsAffected if exists
        /// </summary>
        public int EjecutarNonQuery(string spName, Dictionary<string, object> spPars)
        {
            int rowsAffected = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (spPars != null)
                        foreach (var p in spPars)
                        {
                            cmd.Parameters.AddWithValue(p.Key, p.Value ?? DBNull.Value);
                        }

                    // optional output param
                    SqlParameter outParam = new SqlParameter("@rowsAffected", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };


                    cmd.Parameters.Add(outParam);

                    cmd.ExecuteNonQuery();

                    if (outParam.Value != DBNull.Value)
                        rowsAffected = (int)outParam.Value;
                }
            }

            return rowsAffected;
        }


        public int EjecutarNonQuery(string spName,
                            Dictionary<string, object> spPars,
                            Dictionary<string, SqlDbType> outParams,
                            out Dictionary<string, object> outValues)
        {
            int rowsAffected = 0;
            outValues = new Dictionary<string, object>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // INPUT parameters
                    if (spPars != null)
                    {
                        foreach (var p in spPars)
                        {
                            cmd.Parameters.AddWithValue(p.Key, p.Value ?? DBNull.Value);
                        }
                    }

                    // Your existing rowsAffected OUTPUT
                    SqlParameter outRows = new SqlParameter("@rowsAffected", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outRows);

                    // ADD dynamic OUTPUT parameters
                    if (outParams != null)
                    {
                        foreach (var op in outParams)
                        {
                            SqlParameter outParam = new SqlParameter(op.Key, op.Value)
                            {
                                Direction = ParameterDirection.Output
                            };

                            cmd.Parameters.Add(outParam);
                        }
                    }

                    cmd.ExecuteNonQuery();

                    // Read rowsAffected
                    if (outRows.Value != DBNull.Value)
                        rowsAffected = Convert.ToInt32(outRows.Value);

                    // Read other OUTPUT values
                    if (outParams != null)
                    {
                        foreach (var op in outParams.Keys)
                        {
                            var val = cmd.Parameters[op].Value;
                            outValues[op] = (val == DBNull.Value) ? null : val;
                        }
                    }
                }
            }

            return rowsAffected;
        }





        public DataTable GetCitasByGoogleEventIdsTVP(List<string> eventIds)
    {
        var dt = new DataTable();
        if (eventIds == null || eventIds.Count == 0) return dt;

            //using (var conn = new SqlConnection(configSettings.ObtenConectionString))

            using (SqlConnection conn = new SqlConnection(connectionString))
            
        using (var cmd = new SqlCommand("dbo.usp_obtenCitasPorGoogleEventIds", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;

            // Build TVP
            var tvp = new DataTable();
            tvp.Columns.Add("EventId", typeof(string));
            foreach (var id in eventIds)
                tvp.Rows.Add(id);

            var p = cmd.Parameters.AddWithValue("@eventIds", tvp);
            p.SqlDbType = SqlDbType.Structured;
            p.TypeName = "dbo.GoogleEventIdList";

            using (var da = new SqlDataAdapter(cmd))
                da.Fill(dt);

            return dt;
        }
    }


    /// <summary>
    /// Executes raw SQL for insert/update/delete
    /// </summary>
    public string EjecutaSqlNonQuery(string sql)
        {
            string result = string.Empty;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        result = cmd.ExecuteNonQuery().ToString();
                    }
                }
                catch (Exception ex)
                {
                    result = "Error: " + ex.Message;
                }
            }

            return result;
        }

        /// <summary>
        /// Converts a DataRow byte field to Bitmap safely
        /// </summary>
        public Bitmap GetImageFromField(DataRow row, string columnName)
        {
            if (row == null) return null;

            byte[] fotoBytes = row.Field<byte[]>(columnName);
            if (fotoBytes == null || fotoBytes.Length == 0) return null;

            try
            {
                using (MemoryStream ms = new MemoryStream(fotoBytes))
                {
                    return new Bitmap(ms);
                }
            }
            catch
            {
                return null;
            }
        }

        // Dispose pattern
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                // nothing to dispose at class level because each method uses local using blocks
                disposed = true;
            }
        }

        ~DBHelper()
        {
            Dispose(false);
        }
    }
}
