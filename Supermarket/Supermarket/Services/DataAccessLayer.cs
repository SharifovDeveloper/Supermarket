using System;
using System.Data.SqlClient;

namespace Supermarket
{
    internal class DataAccessLayer
    {
        public const string Connection_String = "Data Source=DESKTOP-B7KIDHK\\SQLEXPRESS02;Initial Catalog=Supermarket;Integrated Security=True";

        public static void ExecuteNonQuery(string command)
        {
            SqlConnection connection = new SqlConnection(Connection_String);

            try
            {
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand(command, connection);

                int affectedRows = sqlCommand.ExecuteNonQuery();

                Console.WriteLine($"Number of rows affected: {affectedRows}");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"There was an error executing SQL command... {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong. {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        public static void ExecuteQuery(string query, Action<SqlDataReader> dataReader)
        {
            SqlConnection connection = new SqlConnection(Connection_String);

            try
            {
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand(query, connection);

                SqlDataReader reader = sqlCommand.ExecuteReader();

                dataReader(reader);
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong while reading products. {ex.Message}.");
            }
            finally
            {
                connection.Close();
            }
        }
    }
}

