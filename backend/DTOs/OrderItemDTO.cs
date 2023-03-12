namespace Backend.DTOs;

using Backend.Models;
public class OrderItemDTO : BaseDTO<OrderItem>
{
    public int Quantity { get; set; }
    public int ProductId { get; set; }

    public override void UpdateModel(OrderItem model)
    {
        model.Quantity = Quantity;
        model.ProductId = ProductId;
    }
}