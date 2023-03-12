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
            // .Include(s =>s.Products)
            //    .ThenInclude(s => s.)

            .Include(s => s.Product)
            .OrderBy(s => s.Id)
            .ToListAsync();
    }
}