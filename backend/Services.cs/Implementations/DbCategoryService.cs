namespace Backend.Services;

using Backend.DTOs;
using Backend.Models;
using Backend.Database;
using Microsoft.EntityFrameworkCore;

public class DbCategorySerivce : DbCrudService<Category, CategoryDTO>, ICategoryService
{
    public DbCategorySerivce(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}