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
using static Backend.DTOs.ProductDTO;
using static Backend.Models.Product;

namespace Backend.Controllers
{
    public class ProductController : CrudController<Product, ProductDTO, ProductToReturnDTO>
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


        [HttpGet]
        public async override Task<ActionResult<IReadOnlyList<ProductToReturnDTO>>> GetAll()
        {
            var spec = new DbCrudWithSPecService();

            var products = await _productService.GetAllSpecAsync(spec);

            return products.Select(product => new ProductToReturnDTO
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                Images = product.Images,
                Category = product.Category.Name
            }).ToList();
            
        }

        [HttpGet("{id}")]
        public async override Task<ActionResult<ProductToReturnDTO?>> Get(int id)
        {
            var spec = new DbCrudWithSPecService(id);
            var item = await _productService.GetEntityWithSpec(spec);

            if (item is null)
            {
                return NotFound($"Item with ID {id} is not found");
            }
            return new ProductToReturnDTO
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                Price = item.Price,
                Images = item.Images,
                Category = item.Category.Name
            };

            // if (item is null)
            // {
            //     return NotFound($"Item with ID {id} is not found");
            // }
            // return Ok(new Response<Product>(item));
        }
    }

}