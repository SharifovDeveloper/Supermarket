using System;
using System.Data.SqlClient;

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
            SqlConnection connection = new SqlConnection(
                "Data Source=DESKTOP-B7KIDHK\\SQLEXPRESS02;Initial Catalog=Supermarket;Integrated Security=True");

            try
            {
                connection.Open();

                string command = "SELECT * FROM dbo.Category";
                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = command;

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows) // Agarda keyingi qator bo'lsa true aks xolda false
                {
                    // Ustunlarni nomlari
                    Console.WriteLine("{0}\t{1}", reader.GetName(0), reader.GetName(1));

                    // Keyingi qatorga o'tishga urunib ko'radi
                    // o'ta olsa true aks xolda false
                    while (reader.Read())
                    {
                        object id = reader.GetValue(0);
                        object name = reader.GetValue(1);


                        Console.WriteLine("{0} \t{1} ", id, name);
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

                string command = "SELECT * FROM dbo.Category" +
                    $" WHERE Id = {id};";

                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = command;

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("{0}\t{1}", reader.GetName(0), reader.GetName(1));

                    while (reader.Read())
                    {
                        object name = reader.GetValue(1);


                        Console.WriteLine("{0} \t{1} ", id, name);
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
            SqlConnection connection = new SqlConnection(
              "Data Source=DESKTOP-B7KIDHK\\SQLEXPRESS02;Initial Catalog=Supermarket;Integrated Security=True");

            try
            {
                connection.Open();

                string command = "SELECT * FROM dbo.Category" +
                    $" WHERE CategoryName = '{name}';";

                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = command;

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("{0}\t{1}", reader.GetName(0), reader.GetName(1));

                    while (reader.Read())
                    {
                        object id = reader.GetValue(0);
                        object categoryname = reader.GetValue(1);

                        Console.WriteLine("{0} \t{1} ", id, categoryname);
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
        public void ReadbyCountProducts(int param)
        {
            SqlConnection connection = new SqlConnection(
              "Data Source=DESKTOP-B7KIDHK\\SQLEXPRESS02;Initial Catalog=Supermarket;Integrated Security=True");

            try
            {
                connection.Open();

                string command = "SELECT CategoryName, COUNT(*) AS ProductCount FROM dbo.Category c " +
                                 "INNER JOIN dbo.Product p ON c.Id = p.categoryId " +
                                 $"GROUP BY CategoryName HAVING COUNT(*) > {param};";


                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = command;

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("{0}\t{1}", reader.GetName(0), reader.GetName(1));

                    while (reader.Read())
                    {
                        object id = reader.GetValue(0);
                        object categoryname = reader.GetValue(1);

                        Console.WriteLine("{0} \t{1} ", id, categoryname);
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




    }
}

