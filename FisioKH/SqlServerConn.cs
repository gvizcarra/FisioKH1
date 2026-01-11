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

        // Method to retrieve data from SQL Server
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
        } public DataSet ObtenerDatos(string sql,string dsname)
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


        public string EjecutaSql(String sql)
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



    }
}
