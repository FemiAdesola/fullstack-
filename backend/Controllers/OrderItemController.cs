using AutoMapper;
using Backend.DTOs;
using Backend.Models;
using Backend.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Controllers
{
    public class OrderItemController : CrudController<OrderItem, OrderItemDTO, OrderItemToReturnDTO>
    {
        private readonly IOrderItemService _orderItemService;
        private readonly ILogger<OrderItemController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;

        public OrderItemController(
            IOrderItemService service, 
            ILogger<OrderItemController> logger,
            IMapper mapper,
            IAuthorizationService authorizationService
            ) : base(service, mapper, authorizationService)
        {
            _orderItemService = service;
            _logger = logger;
            _mapper = mapper;
            _authorizationService = authorizationService;
        }

        [HttpPost("{id}/add-product")]
        public async Task<IActionResult> AddProducts(int id, IEnumerable<AddProductToOrderItemDTO> request)
        {
            var added = await _orderItemService.AddProductsAsync(id, request);
            if (added <= 0)
            {
                return BadRequest("No valid product found");
            }
            else
            {
                return Ok(new { Count = added });
            }
        }
    }
}