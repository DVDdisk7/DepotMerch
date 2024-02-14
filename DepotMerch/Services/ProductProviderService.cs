using DepotMerch.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Immutable;
using static System.Net.Mime.MediaTypeNames;

namespace DepotMerch.Services
{
    public class ProductProviderService
    {
        /* public static readonly ImmutableList<Product> Products = ImmutableList.CreateRange(new List<Product>()
    {
        new()
        {
            Id = Guid.NewGuid(),
            Name = "All roads lead to Blazor Server",
            Description = "A tutorial book for Blazor Server technology",
            Price = 70
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "All roads lead to Blazor WASM",
            Description = "A tutorial book for Blazor WASM technology.",
            Price = 70
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "gRPC for Blazor WASM",
            Description = "A tutorial book for developing a backend for Blazor WASM technology.",
            Price = 100
        }
    }); */
        
        public static ImmutableList<Product> Products
        {
            get
            {
                var products = ImmutableList.CreateBuilder<Product>();
                using var connection = new SqlConnection("Data Source=(local);Initial Catalog=DepotMerch;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
                connection.Open();
                using var command = new SqlCommand("SELECT * FROM Products", connection);
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                        Price = reader.GetDouble(3),
                        Image = reader.GetString(4)
                       
                    });
                }
                return products.ToImmutable();
            }
        }
    }
}
