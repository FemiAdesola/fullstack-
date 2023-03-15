using Backend.DTOs;
using Backend.Models;
using Backend.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/v1/categories")]
    public class CategoryController : CrudController<Category, CategoryDTO, CategoryToReturnDTO>
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