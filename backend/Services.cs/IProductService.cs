namespace Backend.Services;

using Backend.DTOs;
using Backend.Models;

public interface IProductService : ICrudService<Product, ProductDTO>
{
    Task<ICollection<Product>> GetProductsByCategoryIdAsync(int id);
}
