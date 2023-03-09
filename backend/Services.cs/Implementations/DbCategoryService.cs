namespace Backend.Services;

using System.Collections.Generic;
using Backend.DTOs;
using Backend.Models;
using System.Threading.Tasks;
//using Backend.Db;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;

public class DbCategorySerivce : DbCrudService<Category, CategoryDTO>, ICategoryService
{
    
}