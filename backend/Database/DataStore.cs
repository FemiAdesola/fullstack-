using System.Text.Json;
using Backend.Models;

namespace Backend.Database
{
    public class DataStore
    {
       public static async Task DataAsync(AppDbContext context, ILoggerFactory loggerFactory)
        {
            if (!context.Categories.Any())
            {
                var categoryData = File.ReadAllText("../Database/Data/categories.json");

                var category = JsonSerializer.Deserialize<List<Category>>(categoryData);

                foreach (var it in category!)
                {
                    context.Categories.Add(it);
                }
                await context.SaveChangesAsync();
            }


            if (!context.Products.Any())
            {
                var productData = File.ReadAllText("../Database/Data/products.json");

                var product = JsonSerializer.Deserialize<List<Product>>(productData);

                foreach (var it in product!)
                {
                    context.Products.Add(it);
                }
                await context.SaveChangesAsync();
            }
        }
    }
}