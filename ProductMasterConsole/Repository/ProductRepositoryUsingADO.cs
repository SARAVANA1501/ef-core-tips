using System.Collections.Generic;
using System.Data.Common;
using ProductMasterConsole.Model;
using Npgsql;

namespace ProductMasterConsole.Repository
{
    public class ProductRepositoryUsingADO
    {
        public Product[] AllProducts()
        {
            
            //create connection.
            using (NpgsqlConnection connection = new NpgsqlConnection(
                "Server=localhost;Database=ef-tips;User ID=postgres;password=postgres@123;timeout=1000;")
            )
            {
                //Write SQL query as per the underlying database
                string sql = "select * from public.product";
                //Create command to execute query.
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    connection.Open();
                    return command.ExecuteReader().AsProductArray();
                }
            }
        }
    }

    public static class RepositoryExtensionMethods
    {
        public static Product[] AsProductArray(this DbDataReader reader)
        {
            if (!reader.HasRows)
                return new Product[0];
            var result = new List<Product>();
            while (reader.Read())
            {
                result.Add(new Product()
                {
                    Id = reader.GetInt32(0),
                    ProductName = reader.GetString(1),
                    CreatedDate = reader.GetDateTime(2)
                });
            }
            return result.ToArray();
        }
    }
}