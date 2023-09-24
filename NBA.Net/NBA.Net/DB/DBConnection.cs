using Microsoft.Data.SqlClient;
using System.Data;

namespace NBA.Net.DB
{
    public class DBConnection
    {

        public SqlConnectionStringBuilder ConnectToDB()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(GetConnectionString());

            // The input connection string used the
            // Server key, but the new connection string uses
            // the well-known Data Source key instead.
            Console.WriteLine(builder.ConnectionString);

            // Pass the SqlConnectionStringBuilder an existing
            // connection string, and you can retrieve and
            // modify any of the elements.
            builder.ConnectionString = "Data Source=TEJ-LAPTOP;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";



            // Now that the connection string has been parsed,
            // you can work with individual items.
            Console.WriteLine(builder.Password);
            builder.Password = "new@1Password";

            // You can refer to connection keys using strings,
            // as well. When you use this technique (the default
            // Item property in Visual Basic, or the indexer in C#),
            // you can specify any synonym for the connection string key
            // name.
            builder["Server"] = ".";
            builder["Connect Timeout"] = 1000;
            builder["Trusted_Connection"] = true;

            return builder;
            //Console.WriteLine(builder.ConnectionString);


            //using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            //{
            //    Console.WriteLine("\nQuery data example:");
            //    Console.WriteLine("=========================================\n");

            //    connection.Open();

            //    string sql = "SELECT TOP (1000) [TeamID],[Name],[Stadium],[Logo],[URL]FROM [NBA].[dbo].[Teams]";

            //    using (SqlCommand command = new SqlCommand(sql, connection))
            //    {
            //        using (SqlDataReader reader = command.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                Console.WriteLine("{0} {1}", reader.GetInt32(0), reader.GetString(1));
            //            }
            //        }
            //    }
            //}

            //Console.WriteLine("Press Enter to finish.");
            //Console.ReadLine();
        }

        private static string GetConnectionString()
        {
            // To avoid storing the connection string in your code,
            // you can retrieve it from a configuration file.
            return "Server=(local);Integrated Security=SSPI;" +
                "Initial Catalog=AdventureWorks";
        }
    }
}
