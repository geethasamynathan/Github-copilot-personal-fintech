using Microsoft.EntityFrameworkCore;
using EcommerceApi.Models;

namespace EcommerceApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryId);
                entity.Property(e => e.CategoryName).IsRequired();

                entity.HasMany(e => e.Products)
                      .WithOne(p => p.Category)
                      .HasForeignKey(p => p.CategoryId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId);
                entity.Property(e => e.ProductName).IsRequired();
                entity.Property(e => e.Price).HasPrecision(18, 2);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);
                entity.Property(e => e.FullName).IsRequired();
                entity.Property(e => e.Email).IsRequired();

                entity.HasMany(e => e.Orders)
                      .WithOne(o => o.Customer)
                      .HasForeignKey(o => o.CustomerId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderId);
                entity.Property(e => e.TotalAmount).HasPrecision(18, 2);

                entity.HasMany(e => e.OrderItems)
                      .WithOne(oi => oi.Order)
                      .HasForeignKey(oi => oi.OrderId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.OrderItemId);
                entity.Property(e => e.UnitPrice).HasPrecision(18, 2);
                entity.Property(e => e.LineTotal).HasPrecision(18, 2);

                entity.HasOne(e => e.Product)
                      .WithMany()
                      .HasForeignKey(e => e.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
