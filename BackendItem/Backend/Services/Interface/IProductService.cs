using Backend.DTOs;
using Backend.Models;

namespace Backend.Services.Interface
{
    public interface IProductService : ICrudService<Product, ProductDTO>
    {
        Task<ICollection<Product>> GetProductsByCategoryIdAsync(int id);
        Task<int> AddReviewToProuct(int id, IEnumerable<AddReviewToProductDTO> reviews);
    }
}