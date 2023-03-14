using Backend.DTOs;
using Backend.Models;
using Backend.Services.crude;

namespace Backend.Services.ProductService
{
    public interface IProductService : ICrudService<Product, ProductDTO>
    {
        Task<ICollection<Product>> GetProductsByCategoryIdAsync(int id);
    }

}