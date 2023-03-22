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

        modelBuilder.Entity<Order>(entity =>
        {
            entity
                .HasOne(s => s.Address)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            entity
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<OrderItemProduct>()
       .HasKey(ps => new { ps.ProductId, ps.OrderItemId});

        modelBuilder.Entity<Product>().Property(c => c.Title).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<Product>().Property(c => c.Price).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<Product>()
            .HasOne(c => c.Category).WithMany().HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<User>()
           .HasIndex(s => s.Email)
           .IsUnique();

        modelBuilder.Entity<ReviewProduct>()
            .HasKey(ps => new {ps.ReviewId, ps.ProductId });

        modelBuilder.Entity<OrderAndOrderItem>()
            .HasKey(ps => new { ps.OrderItemId, ps.OrderId });
    }
}