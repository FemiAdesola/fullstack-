using AutoMapper;
using Backend.DTOs;
using Backend.Models;
using Backend.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class OrderController : CrudController<Order, OrderDTO, OrderToReturnDTO>
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;
        private readonly IMapper _mapper;

        public OrderController(IOrderService service, 
            ILogger<OrderController> logger, IMapper mapper) : 
            base(service, mapper)
        {
            _orderService = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetOrdersStatusAsync(bool status)
        {
            var orderStatus = await _orderService.GetOrdersStatusAsync(status);
            if (orderStatus.Any())
            {
                return Ok(orderStatus);
            }
            return NotFound("Item you are looking for is not found");
        }

        [HttpPost("{id}/add-orderItem")]
        public async Task<IActionResult> AddReview(int id, ICollection<AddOrderItemToOrderDTO> orderItems)
        {
            var added = await _orderService.AddOrderItemsToOrder(id, orderItems);
            if (added <= 0)
            {
                return BadRequest("No valid review found");
            }
            return Ok(new { Count = added });
        }
    }
}