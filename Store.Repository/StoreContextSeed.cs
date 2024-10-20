using Microsoft.Extensions.Logging;
using Store.Data.Context;
using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Repository
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (context.productsTypes != null && !context.productsTypes.Any())
                {
                    var typesData = File.ReadAllText("../Store.Repository/DataSeeding/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    if (types is not null)
                    {
                        await context.AddRangeAsync(types);
                    }

                }
                if (context.productsBrands != null && !context.productsBrands.Any())
                {
                    var brandData = File.ReadAllText("../Store.Repository/DataSeeding/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);

                    if (brands is not null)
                    {
                        await context.AddRangeAsync(brands);
                    }

                }

              

                if (context.products != null && !context.products.Any())
                {
                    var productsData = File.ReadAllText("../Store.Repository/DataSeeding/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    if (products is not null)
                    {
                        await context.AddRangeAsync(products);
                    }

                }

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                var logger = loggerFactory.CreateLogger<StoreDbContext>();
                logger.LogError(ex.Message);
            }
        }
    }
}
