using CORE.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace INFRASTRUCTURE.Data
{
    public class DataContextSeed
    {

        public static async Task SeedAsync(DataContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("C:/Users/kgatliso matema/source/repos/FDDAPI/IFRASTRUCTURE" + @"/Data/SeedData/types.json");

                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);


                    foreach (var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }

                    await context.SaveChangesAsync();
                }


                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText("C:/Users/kgatliso matema/source/repos/FDDAPI/IFRASTRUCTURE" + @"/Data/SeedData/products.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);


                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<DataContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
