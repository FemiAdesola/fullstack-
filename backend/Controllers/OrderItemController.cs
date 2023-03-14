using Backend.DTOs;
using Backend.Models;
using Backend.Services.OrderItemService;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class OrderItemController : CrudController<OrderItem, OrderItemDTO>
    {
        private readonly IOrderItemService _orderItemService;
        private readonly ILogger<OrderItemController> _logger;

        public OrderItemController(IOrderItemService service, ILogger<OrderItemController> logger) : base(service)
        {
            _orderItemService = service;
            _logger = logger;
        }

        [HttpPost("{id}/add-products")]
        public async Task<IActionResult> AddProducts(int id, ICollection<AddProductToOrderItemDTO> request)
        {
            var added = await _orderItemService.AddProductsAsync(id, request);
            if (added <= 0)
            {
                return BadRequest("No valid product found");
            }
            return Ok(new { Count = added });
        }
    }
}