using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if (!context.Products.Any())
            {

                var productsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/products.json");

                var product = JsonSerializer.Deserialize<List<Product>>(productsData);

                if (product == null) return;

                context.Products.AddRange(product);

                await context.SaveChangesAsync();

            }

        }
    }
}
