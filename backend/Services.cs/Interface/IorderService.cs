namespace Backend.Services;

using Backend.DTOs;
using Backend.Models;

public interface IOrderService : ICrudService<Order, OrderDTO>
{
    Task<ICollection<Order>> GetOrdersStatusAsync(bool isPaid);
}