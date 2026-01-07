using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;




namespace FisioKH
{
    public class SqlDatabase
    {
        // Connection string from app.config
        private string connectionString;
        private string datos;

        
        public SqlConnection ConexionBD()
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                connectionString = configSettings.ObtenConectionString();
                conn = new SqlConnection(connectionString);
                conn.Open();
            }
            catch(Exception ex)
            { ex.ToString(); }
            return conn;
        }

        // Method to retrieve data from SQL Server
        public bool AutenticarUsuario(string usuario, string pass)
        {
            SqlConnection conn = this.ConexionBD();
            bool autenticado = false;

            if (conn.State == ConnectionState.Open)
            {
                try
                {

                    using (conn)
                    {
                         
                        string sql = "SELECT * FROM usuarios WHERE (nombre ='"+ usuario + "' AND password='"+ pass + "') OR (nombre ='" + usuario + "' AND pin='" + pass + "')";  
 
                        SqlCommand cmd = new SqlCommand(sql, conn);
 
                        SqlDataReader rd = cmd.ExecuteReader();
                        if(rd.HasRows)
                        { autenticado = true; }
 
                        rd.Close();
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    datos = "Error: " + ex.Message;
                }
            }
            return autenticado;
        }

           public string GetData()
        {
            SqlConnection conn = this.ConexionBD();

            if (conn.State == ConnectionState.Open)
            {
                try
                {

                    using (conn)
                    {

                        // Open the connection to SQL Server
                        

                        // Define the SQL query
                        string query = "SELECT * FROM usuarios";  // Replace with your actual query

                        // Create SqlCommand object
                        SqlCommand cmd = new SqlCommand(query, conn);

                        // Execute the query and retrieve data
                        SqlDataReader reader = cmd.ExecuteReader();

                        // Read the results and display them
                        while (reader.Read())
                        {
                            // Assuming your table has a column named "ColumnName"
                            datos = reader["nombre"].ToString();
                        }

                        // Close the reader
                        reader.Close();
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
