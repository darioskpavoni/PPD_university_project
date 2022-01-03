using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Proiect
{
    public class Connection
    {
        SqlConnection connection = new SqlConnection();
        SqlCommand command = new SqlCommand();

        public Connection()
        {
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["WebAppConnectionString"].ConnectionString;
            command.Connection = connection;
        }

        public Connection(string connString)
        {
            connection.ConnectionString = ConfigurationManager.ConnectionStrings[connString].ConnectionString;
            command.Connection = connection;
        }

        public string TblAction(string cmdText)
        {
            command.CommandText = cmdText;

            // Executarea comenzii cu deschiderea si inchiderea conexiunii
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                // return $"Operation succeeded: {command.CommandText}";
                // HttpContext.Current.Response.Write("Operatia a fost executata cu succes.");
                return $"Operatia a fost executata cu succes.";

            }
            catch (Exception ex)
            {
                // return $"Operation failed: {ex.Message}";
                
                // HttpContext.Current.Response.Write("A aparut o eroare.");
                return "A aparut o eroare.";

            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable TblExtract(string cmdText)
        {
            DataTable tblData = new DataTable();
            command.CommandText = cmdText;

            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmdText, connection);
                adapter.Fill(tblData);
                return tblData;
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write($"<script>alert('Error: {ex.Message}')</script>");
                return null;
            }
            finally 
            { 
                connection.Close();
            }
        }


    }
}