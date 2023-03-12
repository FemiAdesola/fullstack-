namespace Backend.Controllers;

using Backend.DTOs;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

public class OrderItemController : CrudController<OrderItem, OrderItemDTO>
{
    private readonly IOrderItemService _orderItemService;
    private readonly ILogger<OrderItemController> _logger;

    public OrderItemController(IOrderItemService service, ILogger<OrderItemController> logger) : base(service)
    {
        _orderItemService = service;
        _logger = logger;
    }
}