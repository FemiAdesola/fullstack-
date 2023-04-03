using AutoMapper;
using Backend.DTOs;
using Backend.Models;
using Backend.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Controllers
{
    public class ProductController : CrudController<Product, ProductDTO, ProductToReturnDTO>
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;

        public ProductController(
            IProductService service, 
            ILogger<ProductController> logger,
            IMapper mapper,
            IAuthorizationService authorizationService
            ) : base(service, mapper, authorizationService)
        {
            _productService = service;
            _logger = logger;
            _mapper = mapper;
            _authorizationService = authorizationService;
        }

        [AllowAnonymous]
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

        [HttpPost("{id}/add-review")]
        public async Task<IActionResult> AddReview(int id, IEnumerable<AddReviewToProductDTO> reviews)
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