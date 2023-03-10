namespace Backend.Database;

using Backend.Models;
using Microsoft.EntityFrameworkCore;

public static class CommonEntityExtention
{
    public static void AddICommonConfig(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .Property(s => s.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<Category>()
            .Property(s => s.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<Category>()
            .HasIndex(c => c.Name)
            .IsUnique();
    }
}