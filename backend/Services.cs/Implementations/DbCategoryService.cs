namespace Backend.Services;

using Backend.DTOs;
using Backend.Models;
using Backend.Database;

public class DbCategorySerivce : DbCrudService<Category, CategoryDTO>, ICategoryService
{
    public DbCategorySerivce(AppDbContext dbContext) : base(dbContext)
    {
    }
}