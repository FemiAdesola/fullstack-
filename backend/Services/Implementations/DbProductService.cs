using System.Linq;
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

        public override async Task<ICollection<Product>> GetAllAsync()
        {
            return await _dbContext.Products
            .AsNoTracking()
            .Include(s => s.Category)
            .Include(p => p.Reviews)
                .ThenInclude(p => p.Review)
            .OrderByDescending(s => s.CreatedAt)
            .ToListAsync();
        }


        public override async Task<Product?> GetAsync(int id)
        {
            return await _dbContext.Products
                .Include(s => s.Category)
                .Include(p => p.Reviews)
                    .ThenInclude(p => p.Review)
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

        public async Task<int> AddReviewToProuct(int id, ICollection<AddReviewToProductDTO> reviews)
        {
            var product = await GetAsync(id);
            if (product is null)
            {
                return -1;
            }
            var reviewIds = reviews
            .Select( 
                item => new 
                { 
                    item.UserId, 
                    item.ReviewId 
                }
            )
            .ToList();

            var reviewProducts = await _dbContext.Reviews
            .Where(s => reviews.Select(
                item => item.ReviewId
                
                ).ToList().Contains(s.Id))
            .ToListAsync();

            foreach (var item in reviews)
            {
                product.Reviews.Add(new ReviewProduct
                {
                    ReviewId = item.ReviewId,
                });
            }
            await _dbContext.SaveChangesAsync();
            return reviewProducts.Count();
        }
    }
}