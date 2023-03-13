namespace Backend.Models;

using System.Text.Json.Serialization;

public class OrderItemProduct
{
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

    [JsonIgnore]
    public int OrderItemId { get; set; }
}