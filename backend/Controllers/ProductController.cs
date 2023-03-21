using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.DTOs;
using Backend.Helper;
using Backend.Models;
using Backend.Services.Interface;
using Microsoft.AspNetCore.Mvc;


namespace Backend.Controllers
{
    public class ProductController : CrudController<Product, ProductDTO, ProductToReturnDTO>
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;

        public ProductController(IProductService service, ILogger<ProductController> logger, IMapper mapper) : base(service, mapper)
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

        [HttpPost("{id}/reviews")]
        public async Task<IActionResult> AddReview(int id, ICollection<AddReviewToProductDTO> reviews)
        {
            var added = await _productService.AddReviewToProuct(id, reviews);
            if (added <= 0)
            {
                return BadRequest("No valid review found");
            }
            return Ok(new { Count = added });
        }
    }

}