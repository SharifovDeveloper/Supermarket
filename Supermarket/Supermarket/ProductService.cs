using System;
using System.Data.SqlClient;

namespace Supermarket
{
    internal class ProductService
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

            DAL.ExecuteNonQuery(command);
        }


        public void ReadAllProducts()
        {
            SqlConnection connection = new SqlConnection(
                "Data Source=DESKTOP-B7KIDHK\\SQLEXPRESS02;Initial Catalog=Supermarket;Integrated Security=True");

            try
            {
                connection.Open();

                string command = "SELECT * FROM dbo.Product";
                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = command;

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows) // Agarda keyingi qator bo'lsa true aks xolda false
                {
                    // Ustunlarni nomlari
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3));

                    // Keyingi qatorga o'tishga urunib ko'radi
                    // o'ta olsa true aks xolda false
                    while (reader.Read())
                    {
                        object id = reader.GetValue(0);
                        object name = reader.GetValue(1);
                        object price = reader.GetValue(2);
                        object catergoryId = reader.GetValue(3);

                        Console.WriteLine("{0} \t{1} \t{2}\t{3}", id, name, price, catergoryId);
                    }
                    Console.WriteLine("Reading finished");
                    reader.Close();

                    Console.WriteLine("Reader disposed.");
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
            finally
            {
                Console.WriteLine("Closing connection...");
                connection.Close();
                Console.WriteLine("Connection closed.");
            }

        }

        public void ReadbyID(int id)
        {
            SqlConnection connection = new SqlConnection(
               "Data Source=DESKTOP-B7KIDHK\\SQLEXPRESS02;Initial Catalog=Supermarket;Integrated Security=True");

            try
            {
                connection.Open();

                string command = "SELECT * FROM dbo.Product" +
                    $" WHERE Id = {id};";

                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = command;

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3));

                    while (reader.Read())
                    {
                        object name = reader.GetValue(1);
                        object price = reader.GetValue(2);
                        object categoryId = reader.GetValue(3);

                        Console.WriteLine("{0} \t{1} \t{2}\t{3}", id, name, price, categoryId);
                    }
                    Console.WriteLine("Reading finished");
                    reader.Close();

                    Console.WriteLine("Reader disposed.");
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
            finally
            {
                Console.WriteLine("Closing connection...");
                connection.Close();
                Console.WriteLine("Connection closed.");
            }
        }

        public void GetProductsByCategoryId(int categoryId)
        {
            SqlConnection connection = new SqlConnection(
                "Data Source=DESKTOP-B7KIDHK\\SQLEXPRESS02;Initial Catalog=Supermarket;Integrated Security=True");

            try
            {
                connection.Open();

                string command = "SELECT * FROM dbo.Product" +
                    $" WHERE CategoryId = '{categoryId}';";
                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = command;

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows) // Agarda keyingi qator bo'lsa true aks xolda false
                {
                    // Ustunlarni nomlari
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3));

                    // Keyingi qatorga o'tishga urunib ko'radi
                    // o'ta olsa true aks xolda false
                    while (reader.Read())
                    {
                        object id = reader.GetValue(0);
                        object name = reader.GetValue(1);
                        object price = reader.GetValue(2);
                        object catergoryId = reader.GetValue(3);

                        Console.WriteLine("{0} \t{1} \t{2}\t{3}", id, name, price, catergoryId);
                    }
                    Console.WriteLine("Reading finished");
                    reader.Close();

                    Console.WriteLine("Reader disposed.");
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
            finally
            {
                Console.WriteLine("Closing connection...");
                connection.Close();
                Console.WriteLine("Connection closed.");
            }
        }

        public void UpdateProduct(int id, string newName, decimal newPrice)
        {
            string command = $"UPDATE dbo.Product" +
                    $" SET ProductName = '{newName}', Price = {newPrice}" +
                    $" WHERE Id = {id};";

            DAL.ExecuteNonQuery(command);

        }

        public void DeleteProduct(int id)
        {
            string command = $"DELETE dbo.Product WHERE Id = {id}";

            DAL.ExecuteNonQuery(command);

        }
        public void ReadbyName(string name)
        {
            SqlConnection connection = new SqlConnection(
              "Data Source=DESKTOP-B7KIDHK\\SQLEXPRESS02;Initial Catalog=Supermarket;Integrated Security=True");

            try
            {
                connection.Open();

                string command = "SELECT * FROM dbo.Product" +
                    $" WHERE ProductName = '{name}';";

                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = command;

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3));

                    while (reader.Read())
                    {
                        object id = reader.GetValue(0);
                        object price = reader.GetValue(2);
                        object categoryId = reader.GetValue(3);

                        Console.WriteLine("{0} \t{1} \t{2}\t{3}", id, name, price, categoryId);
                    }
                    Console.WriteLine("Reading finished");
                    reader.Close();

                    Console.WriteLine("Reader disposed.");
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
            finally
            {
                Console.WriteLine("Closing connection...");
                connection.Close();
                Console.WriteLine("Connection closed.");
            }
        }
        public void ReadbyPrice(decimal price)
        {
            SqlConnection connection = new SqlConnection(
              "Data Source=DESKTOP-B7KIDHK\\SQLEXPRESS02;Initial Catalog=Supermarket;Integrated Security=True");

            try
            {
                connection.Open();

                string command = "SELECT * FROM dbo.Product" +
                    $" WHERE Price > '{price}';";

                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = command;

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3));

                    while (reader.Read())
                    {
                        object id = reader.GetValue(0);
                        object name = reader.GetValue(1);
                        object categoryId = reader.GetValue(3);

                        Console.WriteLine("{0} \t{1} \t{2}\t{3}", id, name, price, categoryId);
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
            finally
            {
                Console.WriteLine("Closing connection...");
                connection.Close();
                Console.WriteLine("Connection closed.");
            }


        }

    }
}
