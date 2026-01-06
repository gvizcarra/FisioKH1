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

        public SqlDatabase()
        {
            // Retrieve the connection string from app.config
            connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;

        }

        // Method to retrieve data from SQL Server
        public string GetData()
        {
           

            try
            {
                
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    
                    // Open the connection to SQL Server
                    conn.Open();

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
            }
            catch (Exception ex)
            {
                datos = "Error: " + ex.Message;
            }
            return datos;
        }

        
        
    }
}
