using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;




namespace FisioKH
{
    public class SqlDatabase
    {
        // Connection string from app.config
        private string connectionString;
        private string datos;
        Usuario usr = new Usuario();
        
/// <summary>
/// se conecta a bd sql, obteniendo parametros del app.config
/// </summary>
/// <returns>regresa una conexion abierta</returns>
        public SqlConnection ConexionBD()
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                connectionString = configSettings.ObtenConectionString;
                conn = new SqlConnection(connectionString);
                conn.Open();
            }
            catch(Exception ex)
            {
              usr.ErrorLogin = ex.Message.ToString() + " conn: "+ connectionString;
              ex.ToString();
            }
            return conn;
        }

     /// <summary>
     /// metodo para iniciar session
     /// </summary>
     /// <param name="usuario">usuario</param>
     /// <param name="pass">pass o pin</param>
     /// <returns></returns>
        public Usuario AutenticarUsuario(string usuario, string pass)
        {
             SqlConnection conn = this.ConexionBD();
           
            if (conn.State == ConnectionState.Open)
            {
                try
                {

                    using (conn)
                    {
                         
                        string sql = "SELECT * FROM usuarios WHERE (nombre ='"+ usuario + "' AND password='"+ pass + "') OR (nombre ='" + usuario + "' AND pin='" + pass + "')";  
 
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.CommandTimeout = 5;

                        SqlDataReader rd = cmd.ExecuteReader();
                        if(rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                usr.Id = Convert.ToInt32(rd["id"]);
                                usr.Nombre = rd["id"].ToString();
                                usr.Nivel = Convert.ToInt32(rd.GetOrdinal("nivel"));
                                usr.Activo = Convert.ToBoolean(rd["activo"]);
                                usr.FechaRegistro = rd["fechaRegistro"].ToString();
                                usr.Autenticado = true;                                
                            }                            
                        }
                        else
                        {
                            usr.Autenticado = false;
                            usr.ErrorLogin = "Credenciales Invalidas!";

                        }

 
                        rd.Close();
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    usr.ErrorLogin = "Error: " + ex.Message;
                }
            }
            return usr;
        }
        /// <summary>
        /// ejeuta un stored procedure pasandole el nombre y parametros,regresa dataset con el nombre de tabla que es el parametros dsname
        /// </summary>
        /// <param name="spName">nombre del stored procedure</param>
        /// <param name="dsname">nombre del ds, tabla de bd para uso posterior en logica</param>
        /// <param name="spPars">Dictionary con parametros, nombre parametro y valor de este Dictionary<string, object></param>
        /// <returns></returns>
        public DataSet ObtenerDatos(string spName,string dsname, Dictionary<string, object> spPars)
        {
            SqlConnection conn = this.ConexionBD();
            DataSet ds = new DataSet();

            if (conn.State == ConnectionState.Open)
            {
                try
                {

                    using (conn)
                    { 
                        using (SqlDataAdapter adapter = new SqlDataAdapter(spName, conn))
                        {

                            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                            foreach (var par in spPars)
                            {
                                adapter.SelectCommand.Parameters.AddWithValue(par.Key, par.Value);

                            }
                            
                            adapter.Fill(ds, dsname);  
                        }
 
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    datos = "Error: " + ex.Message;
                }
            }
            return ds;
        }

        /// <summary>
        /// ejecuta una consulta previamente estructurada lista para ejecutar en bd, le pasamos el dsname que es nombre de tabla u objeto
        /// </summary>
        /// <param name="sql">Consulta estructurada para ejecucion</param>
        /// <param name="dsname">nombre del ds, tabla de bd para uso posterior en logica</param>
        /// <returns></returns>
        public DataSet ObtenerDatos(string sql,string dsname)
        {
            SqlConnection conn = this.ConexionBD();
            DataSet ds = new DataSet();

            if (conn.State == ConnectionState.Open)
            {
                try
                {

                    using (conn)
                    { 
                        using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
                        {
 
                            adapter.Fill(ds, dsname); 
                        }
 
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    datos = "Error: " + ex.Message;
                }
            }
            return ds;
        }

        /// <summary>
        /// recibe consulta sql para eejecutar,solo insert updatey delete, no regresa registros
        /// </summary>
        /// <param name="sql">sql como insert,update,delete</param>
        /// <returns></returns>
        public string EjecutaSqlNonQuery(String sql)
        {
            SqlConnection conn = this.ConexionBD();

            if (conn.State == ConnectionState.Open)
            {
                try
                {

                    using (conn)
                    {   
                       SqlCommand cmd = new SqlCommand(sql, conn);
                       string datos = cmd.ExecuteNonQuery().ToString();
 
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    datos = "Error: " + ex.Message;
                }
            }
            return datos;
        }
        /// <summary>
        /// recibe consulta sql para eejecutar,solo insert updatey delete, no regresa registros
        /// </summary>
        /// <param name="sql">sql como insert,update,delete</param>
        /// <returns></returns>
        public int EjecutarNonQuery(string spName, Dictionary<string, object> spPars)
        {
            int rowsAffected = 0;

            using (SqlConnection conn = this.ConexionBD())
            {
                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (spPars != null)
                    {
                        foreach (var par in spPars)
                        {
                            cmd.Parameters.AddWithValue(par.Key, par.Value ?? DBNull.Value);
                        }
                    }

                    SqlParameter outParam = new SqlParameter("@rowsAffected", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outParam);

                    cmd.ExecuteNonQuery();

                    rowsAffected = (int)outParam.Value;

                    

                }
            }

            return rowsAffected;
        }



    }
}
