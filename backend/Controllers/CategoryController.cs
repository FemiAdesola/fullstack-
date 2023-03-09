namespace Backend.Controllers;

using Backend.DTOs;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Exceptions;

public class CategoryController : CrudController<Category, CategoryDTO>
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService service) : base(service)
    {
        _categoryService = service;
    }
}
