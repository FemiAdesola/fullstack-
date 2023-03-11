namespace Backend.Services;

using Backend.DTOs;
using Backend.Models;
using Backend.Database;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

public class DbOrderSerivce : DbCrudService<Order, OrderDTO>, IOrderService
{
    public DbOrderSerivce(AppDbContext dbContext) : base(dbContext)
    {

    }

    public override async Task<ICollection<Order>> GetAllAsync()
    {
        return await _dbContext.Orders
            .AsNoTracking()
            .Include(s => s.Address)
            .OrderBy(s => s.Id)
            .ToListAsync();
    }

    public override async Task<Order?> GetAsync(int id)
    {
        var product = await base.GetAsync(id);
        if (product is null)
        {
            return null;
        }
        await _dbContext.Entry(product).Reference(s => s.Address).LoadAsync();
        return product;
    }

    public async Task<ICollection<Order>> GetOrdersStatusAsync(bool isPaid)
    {
        return await _dbContext.Orders
            .Include(s => s.Address)
            .Where(c => c.IsPaid.Equals(isPaid))
            .ToListAsync();
    }
}