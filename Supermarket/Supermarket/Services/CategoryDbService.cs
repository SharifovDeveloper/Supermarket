using System;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Supermarket
{
    internal class Category
    {
        public void CreateCategory(string categoryName)
        {
            // CRUD operations
            // Create
            // ReadAll
            // ReadById
            // Update
            // Delete
            // ReadByCategoryId
            // ReadByName
            // ReadByPrice > 500

            string command = $"INSERT INTO dbo.Category (categoryName) VALUES ('{categoryName}')";
            DAL.ExecuteNonQuery(command);

        }
       
        public void ReadAllCategory()
        {
            string command = "SELECT * FROM dbo.Category";
            try
            {
                using (SqlConnection connection = new SqlConnection(DAL.Connection_String))
                {
                    connection.Open();

                    SqlCommand sqlCommand = new SqlCommand(command, connection);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        ReadCategorysFromDataReader(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong while reading products. {ex.Message}.");
            }

        }
        
        public void ReadbyID(int id)
        {
            string command = "SELECT * FROM dbo.Category" +
                        $" WHERE Id = {id};";
            try
            {
                using (SqlConnection connection = new SqlConnection(DAL.Connection_String))
                {
                    connection.Open();

                    SqlCommand sqlCommand = new SqlCommand(command, connection);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        ReadCategorysFromDataReader(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong while reading products. {ex.Message}.");
            }
        }
        public void UpdateCategory(int id, string newName)
        {
            string command = $"UPDATE dbo.Category" +
                     $" SET CategoryName = '{newName}'" +
                     $" WHERE Id = {id};";

            DAL.ExecuteNonQuery(command);
        }
        public void DeleteCategory(int id)
        {
            string command = $"DELETE dbo.Category WHERE Id = {id}";
            DAL.ExecuteNonQuery(command);

        }
       
        public void ReadbyName(string name)

        {
            string command = "SELECT * FROM dbo.Category" +
                      $" WHERE CategoryName = '{name}';";
            try
            {
                using (SqlConnection connection = new SqlConnection(DAL.Connection_String))
                {
                    connection.Open();

                    SqlCommand sqlCommand = new SqlCommand(command, connection);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        ReadCategorysFromDataReader(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong while reading products. {ex.Message}.");
            }


        }
      
        public void ReadbyCountProducts(int param)
        {
            string command = "SELECT CategoryName, COUNT(*) AS ProductCount FROM dbo.Category c " +
                                    "INNER JOIN dbo.Product p ON c.Id = p.categoryId " +
                                    $"GROUP BY CategoryName HAVING COUNT(*) > {param};";
            try
            {
                using (SqlConnection connection = new SqlConnection(DAL.Connection_String))
                {
                    connection.Open();

                    SqlCommand sqlCommand = new SqlCommand(command, connection);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        ReadCategorysFromDataReader(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong while reading products. {ex.Message}.");
            }

        }

        private static void ReadCategorysFromDataReader(SqlDataReader reader)
        {
            if (reader is null)
            {
                return;
            }

            if (reader.HasRows)
            {
                Console.WriteLine("{0}\t{1}",
                    reader.GetName(0),
                    reader.GetName(1));
;

                while (reader.Read())
                {
                    object id = reader.GetValue(0);
                    object name = reader.GetValue(1);
              

                    Console.WriteLine("{0} \t{1} ", id, name);
                }
                reader.Close();
            }
        }
    }
}

