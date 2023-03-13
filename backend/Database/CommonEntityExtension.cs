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
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<OrderItemProduct>()
       .HasKey(ps => new { ps.ProductId, ps.OrderItemId})
       ;
    }
}