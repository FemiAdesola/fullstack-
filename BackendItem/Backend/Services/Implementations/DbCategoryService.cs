using Backend.Database;
using Backend.DTOs;
using Backend.Models;
using Backend.Services.Interface;

namespace Backend.Services.Implementations
{
    public class DbCategorySerivce : DbCrudService<Category, CategoryDTO>, ICategoryService
    {
        public DbCategorySerivce(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}