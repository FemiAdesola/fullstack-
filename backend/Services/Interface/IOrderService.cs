using Backend.DTOs;
using Backend.Models;

namespace Backend.Services.Interface
{
    public interface IOrderService : ICrudService<Order, OrderDTO>
    {
        Task<ICollection<Order>> GetOrdersStatusAsync(bool isPaid);
    }
}