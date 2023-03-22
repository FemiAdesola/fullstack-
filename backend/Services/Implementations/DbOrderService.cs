using Backend.Database;
using Backend.DTOs;
using Backend.Models;
using Backend.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.Implementations
{
    public class DbOrderSerivce : DbCrudService<Order, OrderDTO>, IOrderService
    {
        public DbOrderSerivce(AppDbContext dbContext) : base(dbContext)
        {

        }

        public override async Task<IEnumerable<Order>> GetAllAsync(QueryOptions options)
        {
            return await _dbContext.Orders
                .AsNoTracking()
                .Include(s => s.Address)
                .Include(s => s.User)
                .Include(p => p.Orders)
                    .ThenInclude(p => p.OrderItem)
                .OrderBy(s => s.Id)
                .ToListAsync();
        }

        public override async Task<Order?> GetAsync(int id)
        {
            return await _dbContext.Orders
                .Include(s => s.Address)
                .Include(s => s.User)
                .Include(p => p.Orders)
                    .ThenInclude(p => p.OrderItem)
                .OrderByDescending(s => s.CreatedAt)
                .FirstOrDefaultAsync(P => P.Id == id);
        }

        public async Task<ICollection<Order>> GetOrdersStatusAsync(bool isPaid)
        {
            return await _dbContext.Orders
                .Include(s => s.Address)
                .Include(s => s.User)
                .Where(c => c.IsPaid.Equals(isPaid))
                .ToListAsync();
        }

        public async Task<int> AddOrderItemsToOrder(int id, ICollection<AddOrderItemToOrderDTO> orderItems)
        {
            var order = await GetAsync(id);
            if (order is null)
            {
                return -1;
            }
            var orerItemIds = orderItems
            .Select(
                item => new
                {
                    item.OrderItemId
                }
            )
            .ToList();

            var orderItemInOrder = await _dbContext.OrderItems
            .Where(s => orderItems.Select(
                item => item.OrderItemId

                ).ToList().Contains(s.Id))
            .ToListAsync();

            foreach (var item in orderItems)
            {
                order.Orders.Add(new OrderAndOrderItem
                {
                    OrderItemId = item.OrderItemId
                });
            }
            await _dbContext.SaveChangesAsync();
            return orderItemInOrder.Count();
        }
    }
}