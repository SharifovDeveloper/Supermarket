using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Supermarket
{
    internal class ProductDbService
    {
        public void CreateProduct(string name, decimal price, int categoryId)
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

            string command = $"INSERT INTO dbo.Product (ProductName, Price, categoryId) " +
                             $"VALUES ('{name}', {price}, {categoryId})";

            DataAccessLayer.ExecuteNonQuery(command);
        }


        public void ReadAllProducts()
        {
            string command = "SELECT * FROM dbo.Product;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessLayer.Connection_String))
                {
                    connection.Open();

                    SqlCommand sqlCommand = new SqlCommand(command, connection);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        ReadProductFromDataReader(reader);
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
            string command = "SELECT * FROM dbo.Product;" +
                               $"where Productid={id}";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessLayer.Connection_String))
                {
                    connection.Open();

                    SqlCommand sqlCommand = new SqlCommand(command, connection);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        ReadProductFromDataReader(reader);
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

        public void GetProductsByCategoryId(int categoryId)
        {
            string command = "SELECT * FROM dbo.Product;" +
                $"where categoryId={categoryId}";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessLayer.Connection_String))
                {
                    connection.Open();

                    SqlCommand sqlCommand = new SqlCommand(command, connection);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        ReadProductFromDataReader(reader);
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

        public void UpdateProduct(int id, string newName, decimal newPrice)
        {
            string command = $"UPDATE dbo.Product" +
                    $" SET ProductName = '{newName}', Price = {newPrice}" +
                    $" WHERE Id = {id};";

            DataAccessLayer.ExecuteNonQuery(command);

        }

        public void DeleteProduct(int id)
        {
            string command = $"DELETE dbo.Product WHERE Id = {id}";

            DataAccessLayer.ExecuteNonQuery(command);

        }

        public void ReadbyName(string name)
        {
            string command = "SELECT * FROM dbo.Product" +
                $" WHERE ProductName = '{name}';";
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessLayer.Connection_String))
                {
                    connection.Open();

                    SqlCommand sqlCommand = new SqlCommand(command, connection);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        ReadProductFromDataReader(reader);
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

        public void ReadbyPrice(decimal price)
        {
            string command = "SELECT * FROM dbo.Product" +
                 $" WHERE Price > '{price}';";
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessLayer.Connection_String))
                {
                    connection.Open();

                    SqlCommand sqlCommand = new SqlCommand(command, connection);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        ReadProductFromDataReader(reader);
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

        //private static void ReadProductsFromDataReader(SqlDataReader reader)
        //{
        //    if (reader is null)
        //    {
        //        return;
        //    }

        //    if (reader.HasRows)
        //    {
        //        Console.WriteLine("{0}\t{1}\t{2}\t{3}",
        //            reader.GetName(0),
        //            reader.GetName(1),
        //            reader.GetName(2),
        //            reader.GetName(3));

        //        while (reader.Read())
        //        {
        //            object id = reader.GetValue(0);
        //            object name = reader.GetValue(1);
        //            object price = reader.GetValue(2);
        //            object categoryId = reader.GetValue(3);

        //            Console.WriteLine("{0} \t{1} \t{2} \t{3}", id, name, price, categoryId);
        //        }
        //        reader.Close();
        //    }
        //}
        private static List<Product> ExecuteQuery(string query)
        {
            List<Product> products = new List<Product>();
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessLayer.Connection_String))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    products = ReadProductFromDataReader(command.ExecuteReader());
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

            return products;
        }

        private static List<Product> ReadProductFromDataReader(SqlDataReader reader)
        {
            List<Product> products = new List<Product>();
            if (reader == null)
            {
                return products;
            }

            if (!reader.HasRows)
            {
                Console.WriteLine("No data.");
                return products;
            }

            Console.WriteLine("{0}\t{1}\t{2}\t{3}",
                    reader.GetName(0),
                    reader.GetName(1),
                    reader.GetName(2),
                    reader.GetName(3));


            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string productName = reader.GetString(1);
                decimal price = reader.GetDecimal(2);
                int categoryId = reader.GetInt32(3);

                products.Add(new Product(id, productName, price, categoryId));

                Console.WriteLine("{0} \t{1} \t{2}\t{3}", id, productName, price, categoryId);
            }
            reader.Close();

            return products;
        }
    }
}

