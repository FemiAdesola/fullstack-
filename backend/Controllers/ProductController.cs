using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProductController(IProductService service, ILogger<ProductController> logger, IMapper mapper): base( service, mapper)
        {
            _productService = service;
            _logger = logger;
            _mapper = mapper;
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
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList <ProductToReturnDTO>>(products));
            
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
            return _mapper.Map<Product, ProductToReturnDTO>(item);
        }
    }

}