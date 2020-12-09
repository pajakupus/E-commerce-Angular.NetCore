using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Transactions;
using API.Models;
using API.Models.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if(!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../API/Data/SeedData/brands.json");

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var item in brands)
                    {
                        using (var transaction = context.Database.BeginTransaction())
                        {
 
                            context.ProductBrands.Add(item);
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ProductBrands ON");
                            
                            context.SaveChanges();

                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ProductBrands OFF");

                            transaction.Commit();
                        }
                        
                    }
                    await context.SaveChangesAsync();
                }

                 if(!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../API/Data/SeedData/types.json");

                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var item in types)
                    {
                             using (var transaction = context.Database.BeginTransaction())
                        {
 
                            context.ProductTypes.Add(item);
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ProductTypes ON");
                            
                            context.SaveChanges();

                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ProductTypes OFF");

                            transaction.Commit();
                        }
                    }
                    await context.SaveChangesAsync();
                }

                 if(!context.Products.Any())
                {
                    var productsData = File.ReadAllText("../API/Data/SeedData/products.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var item in products)
                    {
                              using (var transaction = context.Database.BeginTransaction())
                        {
 
                            context.Products.Add(item);
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Products ON");
                            
                            context.SaveChanges();

                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Products OFF");

                            transaction.Commit();
                        }
                    }
                    await context.SaveChangesAsync();
                }
                 if(!context.DeliveryMethods.Any())
                {
                    var dmData = File.ReadAllText("../API/Data/SeedData/delivery.json");

                    var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(dmData);

                    foreach (var item in methods)
                    {
 
                         using (var transaction = context.Database.BeginTransaction())
                        {
 
                            context.DeliveryMethods.Add(item);
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.DeliveryMethods ON");
                            
                            context.SaveChanges();

                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.DeliveryMethods OFF");

                            transaction.Commit();
                        }
                    
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}