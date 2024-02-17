using Microsoft.EntityFrameworkCore;
using QueryCraft.SampleApp.Data.Configurations;
using QueryCraft.SampleApp.Models;

namespace QueryCraft.SampleApp.Data
{
    public class QueryCraftContext(DbContextOptions<QueryCraftContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.SeedDatabase();

            base.OnModelCreating(modelBuilder);
        }
    }
}
