using Backend.DTOs;
using Backend.Models;
using Backend.Services.crude;

namespace Backend.Services.CategoryService
{
    public interface ICategoryService : ICrudService<Category, CategoryDTO>
    {

    }
}