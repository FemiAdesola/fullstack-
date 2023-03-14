using Backend.DTOs;
using Backend.Models;
using Backend.Services.crude;

namespace Backend.Services.OrderItemService
{
    public interface IOrderItemService : ICrudService<OrderItem, OrderItemDTO>
    {
        Task<int> AddProductsAsync(int id, ICollection<AddProductToOrderItemDTO> products);
    }
}