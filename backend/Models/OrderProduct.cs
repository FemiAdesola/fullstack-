using System.Text.Json.Serialization;

namespace Backend.Models;

public class OrderProduct
{
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
}