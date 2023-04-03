using Backend.Database;
using Backend.DTOs;
using Backend.Models;
using Backend.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.Implementations
{
    public class DbOrderItemSerivce : DbCrudService<OrderItem, OrderItemDTO>, IOrderItemService
    {
        public DbOrderItemSerivce(AppDbContext dbContext) : base(dbContext)
        {

        }

        public override async Task<IEnumerable<OrderItem>> GetAllAsync(QueryOptions options)
        {
            var filter = (QueryOptions?)options;
            return await _dbContext.OrderItems
                .AsNoTracking()
                .Include(s => s.ProductLists)
                   .ThenInclude(s => s.Product)
                .OrderBy(s => s.Id)
                .Skip((filter!.Skip - 1) * filter.Limit)
                .Take(filter.Limit)
                .OrderByDescending(c => c.Id)
                .ToListAsync();
        }

        public override async Task<OrderItem?> GetAsync(int id)
        {
            return await _dbContext.OrderItems
            .Include(p => p.ProductLists)
                .ThenInclude(p => p.Product)
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<int> AddProductsAsync(int id, IEnumerable<AddProductToOrderItemDTO> request)
        {
            var orderItem = await GetAsync(id);
            if (orderItem is null)
            {
                return -1;
            }
            var productIds = request
            .Select(item => item.ProductId)
            .ToList();

            var products = await _dbContext.OrderItems
            .Where(s => request.Select(item => item.ProductId).ToList().Contains(s.Id))
            .ToListAsync();

            foreach (var item in request)
            {
                orderItem.ProductLists.Add(new OrderItemProduct
                {
                    ProductId = item.ProductId,
                });
            }
            await _dbContext.SaveChangesAsync();
            return products.Count();
        }
    }
}