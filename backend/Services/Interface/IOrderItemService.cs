using Backend.DTOs;
using Backend.Models;

namespace Backend.Services.Interface
{
    public interface IOrderItemService : ICrudService<OrderItem, OrderItemDTO>
    {
        Task<int> AddProductsAsync(int id, ICollection<AddProductToOrderItemDTO> products);
    }
}