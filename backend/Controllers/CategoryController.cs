namespace Backend.Controllers;

using Backend.DTOs;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;


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