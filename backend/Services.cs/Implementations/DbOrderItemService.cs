namespace Backend.Services;

using Backend.DTOs;
using Backend.Models;
using Backend.Database;
using Microsoft.EntityFrameworkCore;

public class DbOrderItemSerivce : DbCrudService<OrderItem, OrderItemDTO>, IOrderItemService
{
    public DbOrderItemSerivce(AppDbContext dbContext) : base(dbContext)
    {

    }

    public override async Task<ICollection<OrderItem>> GetAllAsync()
    {
        return await _dbContext.OrderItems
            .AsNoTracking()
            .Include(s =>s.ProductLists)
               .ThenInclude(s => s.Product)
            .OrderBy(s => s.Id)
            .ToListAsync();
    }

    public override async Task<OrderItem?> GetAsync(int id)
    {
        return await _dbContext.OrderItems
        .Include(p => p.ProductLists)
            .ThenInclude(p => p.Product)
        .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<int> AddProductsAsync(int id, ICollection<AddProductToOrderItemDTO> request)
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