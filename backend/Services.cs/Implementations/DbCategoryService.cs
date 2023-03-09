namespace Backend.Services;

using System.Collections.Generic;
using Backend.DTOs;
using Backend.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using Backend.Database;

public class DbCategorySerivce : DbCrudService<Category, CategoryDTO>, ICategoryService
{
    public DbCategorySerivce(AppDbContext dbContext) : base(dbContext)
    {
    }
}