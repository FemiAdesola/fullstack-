namespace Backend.Database;

using Backend.Models;
using Microsoft.EntityFrameworkCore;

public static class CommonEntityExtention
{
    public static void AddICommonConfig(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasIndex(c => c.Name)
            .IsUnique();

        modelBuilder.Entity<Order>()
            .HasOne(s => s.Address)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrderItemProduct>()
       .HasKey(ps => new { ps.ProductId, ps.OrderItemId})
       ;

// products
        modelBuilder.Entity<Product>().Property(c => c.Title).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<Product>().Property(c => c.Price).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<Product>()
            .HasOne(c => c.Category).WithMany().HasForeignKey(p => p.CategoryId);
        // modelBuilder.Entity<Product>()
        //     .HasOne(c => c.ProductBrand).WithMany().HasForeignKey(p => p.ProductBrandId);
    }
}