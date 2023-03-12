using System.Text.Json.Serialization;

namespace Backend.Models;

public class OrderItem : BaseModel
{
    public int Quantity { get; set; }

    [JsonIgnore]
    public int ProductId { get; set; }

    public Product Product  { get; set; } = null!;
    public List <Product> Products { get; set; } = null!; // TODO:
    // public ICollection<OrderProduct> Products { get; set; } = null!;
} 