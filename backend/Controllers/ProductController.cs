using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.common;
using Backend.DTOs;
using Backend.Models;
using Backend.Services.Implementations;
using Backend.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class ProductController : CrudController<Product, ProductDTO>
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService service, ILogger<ProductController> logger) : base(service)
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
            return NotFound("Item you are looking for is not found");
        }


        [HttpGet("categories")]
        public async Task<IActionResult> GetProductsWithSpecCategoryAsync(int id)
        {
            var spec = new DbCrudWithSPecService();

            var products = await _productService.GetAllSpecAsync(spec);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async override Task<ActionResult<Product?>> Get(int id)
        {
            var spec = new DbCrudWithSPecService(id);
            var item = await _productService.GetEntityWithSpec(spec);

            if (item is null)
            {
                return NotFound($"Item with ID {id} is not found");
            }
            return Ok(new Response<Product>(item));
        }
    }

}