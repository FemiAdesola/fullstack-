namespace Backend.Controllers;

using Backend.DTOs;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

public class ProductController : CrudController<Product, ProductDTO>
{
    private readonly IProductService _productService;
    private readonly ILogger<ProductController> _logger;

    public ProductController(IProductService service, ILogger<ProductController> logger): base(service)
    {
        _productService = service;
        _logger = logger;
    }

    [HttpGet("by-categories/{id}")]
    public async Task<IActionResult> GetProductsByCategoryIdAsync(int id)
    {
        var productCategory = await _productService.GetProductsByCategoryIdAsync(id);
        if (productCategory.Any())
        {
            return Ok(productCategory);
        }
        return NotFound("not found");
    }
}
