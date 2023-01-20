using ECommerceWebApp.Models;
using Newtonsoft.Json;

namespace ECommerceWebApp.Data
{
    public class SeedData
    {
        public static void SeedDB(DatabaseContext context)
        {
            if (context.ProductCategories.Any())
                return;

            var text = File.ReadAllText(@"Categories_Seed.json");
            dynamic data = JsonConvert.DeserializeObject(text);

            List<ProductCategory> productCategories = new();
            foreach (var category in data.ProductCategories)
            {
                productCategories.Add(new ProductCategory()
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                });
            }
            context.AddRange(productCategories);

            List<Product> products = new();
            foreach (var product in data.Products)
            {
                products.Add(new Product()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    ProductCategoryId = product.ProductCategoryId,
                    Quantity = product.Quantity,
                    Image = product.Image,
                });
            }
            context.AddRange(products);
            context.SaveChanges();
        }

    }
}
