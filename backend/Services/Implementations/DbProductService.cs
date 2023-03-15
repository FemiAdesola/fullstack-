using Backend.Database;
using Backend.DTOs;
using Backend.Models;
using Backend.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.Implementations
{
    public class DbProductSerivce : DbCrudService<Product, ProductDTO>, IProductService
    {
        public DbProductSerivce(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            return await _dbContext.Products
            .AsNoTracking()
            .Include(s => s.Category)
            .OrderByDescending(s => s.CreatedAt)
            .ToListAsync();
        }

        public override async Task<Product?> GetAsync(int id)
        {
            // var product = await base.GetAsync(id);
            // if (product is null)
            // {
            //     return null;
            // }
            // await _dbContext.Entry(product).Reference(s => s.Category).LoadAsync();
            // return product;
            return await _dbContext.Products
                .Include(s => s.Category)
                .OrderByDescending(s => s.CreatedAt)
                .FirstOrDefaultAsync(P => P.Id == id);
        }

        public async Task<ICollection<Product>> GetProductsByCategoryIdAsync(int id)
        {
            return await _dbContext.Products
                .Include(s => s.Category)
                .Where(c => c.Category.Id.Equals(id))
                .ToListAsync();
        }
    }
}