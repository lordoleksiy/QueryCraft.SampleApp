using Microsoft.EntityFrameworkCore;
using QueryCraft.SampleApp.Models;

namespace QueryCraft.SampleApp.Data
{
    public static class DataSeeder
    {
        public static void SeedDatabase(this ModelBuilder modelBuilder)
        {
            var categories = new List<Category>()
            {
                new Category { Id = Guid.NewGuid(), Name = "Electronics" },
                new Category { Id = Guid.NewGuid(), Name = "Clothing" },
                new Category { Id = Guid.NewGuid(), Name = "Books" },
            };

            var products = new List<Product>();
            var productCategories = new List<object>();
            var random = new Random();
            var productNames = new[] { "Laptop", "T-Shirt", "Novel", "Smartphone", "Jacket", "Thriller" };

            for (int i = 0; i < 100; i++)
            {
                var name = productNames[random.Next(productNames.Length)];
                var product = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Price = random.Next(10, 1000),
                    Description = $"This is a great {name}!",
                    ReleaseDate = DateTime.Now.AddDays(-random.Next(365)),
                    IsActive = random.Next(2) == 0,
                    StockQuantity = random.Next(10, 50)
                };
                foreach (var category in categories.GetRandomSubset(random, 1, 3))
                {
                    productCategories.Add(
                        new { CategoriesId = category.Id, ProductsId = product.Id});
                }
                products.Add(product);
            }

            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Categories)
                .WithMany(p => p.Products)
                .UsingEntity(j => j.ToTable("ProductCategory")
                .HasData(productCategories));
        }

        private static ICollection<T> GetRandomSubset<T>(this IList<T> list, Random random, int minCount, int maxCount)
        {
            int count = random.Next(minCount, maxCount + 1);
            return list.OrderBy(item => random.Next()).Take(count).ToList();
        }
    }
}
