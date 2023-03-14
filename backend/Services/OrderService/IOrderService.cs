using Backend.DTOs;
using Backend.Models;
using Backend.Services.crude;

namespace Backend.Services.OrderService
{
    public interface IOrderService : ICrudService<Order, OrderDTO>
    {
        Task<ICollection<Order>> GetOrdersStatusAsync(bool isPaid);
    }
}