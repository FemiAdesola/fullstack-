namespace Backend.Services;

using Backend.DTOs;
using Backend.Models;
using Backend.Database;
using Microsoft.EntityFrameworkCore;

public class DbProductSerivce : DbCrudService<Product, ProductDTO>, IProductService
{
    public DbProductSerivce(AppDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<ICollection<Product>> GetAllAsync()
    {
        return await _dbContext.Products
        .AsNoTracking()
        .Include(s => s.Category)
        .OrderByDescending(s => s.CreatedAt)
        .ToListAsync();
    }

    public override async Task<Product?> GetAsync(int id)
    {
        var product = await base.GetAsync(id);
        if (product is null)
        {
            return null;
        }
        await _dbContext.Entry(product).Reference(s => s.Category).LoadAsync();
        return product;
    }

    public async Task<ICollection<Product>> GetProductsByCategoryAsync(string category)
    {
        return await _dbContext.Products
            .Include(s => s.Category)
            .Where (c => c.Category.Name.Equals(category))
            .ToListAsync();
    }
}