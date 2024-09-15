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
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}