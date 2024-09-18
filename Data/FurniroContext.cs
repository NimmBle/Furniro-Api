using furniro_server.Models;
using furniro_server.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace furniro_server.Data
{
    public class FurniroContext : DbContext
    {
        public FurniroContext(DbContextOptions<FurniroContext> options) : base(options) {}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>()
                .Property(s => s.Sizes)
                .HasConversion(
                    v => String.Join(",", v),
                    v => v.Split(",", StringSplitOptions.RemoveEmptyEntries)
                          .Select(e => (Sizes)Enum.Parse(typeof(Sizes), e))
                          .ToArray()
                );

            modelBuilder
                .Entity<ProductCart>()
                .HasKey(pc => new { pc.ProductId, pc.CartId });

            modelBuilder
                .Entity<ProductCart>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.)
        }
    }
}