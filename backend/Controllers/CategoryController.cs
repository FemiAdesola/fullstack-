using Backend.DTOs;
using Backend.Models;
using Backend.Services.CategoryService;
using Microsoft.AspNetCore.Components;

namespace Backend.Controllers
{
    [Route("api/v1/categories")]
    public class CategoryController : CrudController<Category, CategoryDTO>
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryService service, ILogger<CategoryController> logger) : base(service)
        {
            _categoryService = service;
            _logger = logger;
        }
    }
}