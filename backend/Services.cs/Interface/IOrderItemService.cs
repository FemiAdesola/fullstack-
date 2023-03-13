namespace Backend.Services;

using Backend.DTOs;
using Backend.Models;

public interface IOrderItemService : ICrudService<OrderItem, OrderItemDTO>
{
   Task<int> AddProductsAsync(int id, ICollection<AddProductToOrderItemDTO> products);
}