using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Supermarket
{
    internal class CategoryDbService
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
            DataAccessLayer.ExecuteNonQuery(command);

        }

        public void ReadAllCategory()
        {
            string query = "SELECT * FROM dbo.Category;";

            ExecuteQuery(query);

        }

        public void ReadbyID(int id)
        {
            string query = "SELECT * FROM dbo.Category" +
                 $" WHERE Id = {id};";

            ExecuteQuery(query);
        }
        public void UpdateCategory(int id, string newName)
        {
            string command = $"UPDATE dbo.Category" +
                     $" SET CategoryName = '{newName}'" +
                     $" WHERE Id = {id};";

            DataAccessLayer.ExecuteNonQuery(command);
        }
        public void DeleteCategory(int id)
        {
            string command = $"DELETE dbo.Category WHERE Id = {id}";
            DataAccessLayer.ExecuteNonQuery(command);

        }

        public void ReadbyName(string name)

        {
            string query = "SELECT * FROM dbo.Category" +
                      $" WHERE CategoryName = '{name}';";
            ExecuteQuery(query);

        }

        public void ReadbyCountProducts(int param)
        {
            string query = "SELECT CategoryName, COUNT(*) AS ProductCount FROM dbo.Category c " +
                                    "INNER JOIN dbo.Product p ON c.Id = p.categoryId " +
                                    $"GROUP BY CategoryName HAVING COUNT(*) > {param};";
            ExecuteQuery(query);
        }

        private static List<Category> ExecuteQuery(string query)
        {
            List<Category> categories = new List<Category>();
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessLayer.Connection_String))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    categories = ReadCategoryFromDataReader(command.ExecuteReader());
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

            return categories;
        }

        private static List<Category> ReadCategoryFromDataReader(SqlDataReader reader)
        {
            List<Category> categories = new List<Category>();
            if (reader == null)
            {
                return categories;
            }

            if (!reader.HasRows)
            {
                Console.WriteLine("No data.");
                return categories;
            }

            Console.WriteLine("{0}\t{1}",
                    reader.GetName(0),
                    reader.GetName(1));
                    

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
               

                categories.Add(new Category(id, name));

                Console.WriteLine("{0} \t{1}", id, name);
            }
            reader.Close();

            return categories;
        }
    }
}

