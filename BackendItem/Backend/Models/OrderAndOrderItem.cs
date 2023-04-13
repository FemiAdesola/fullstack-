using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class OrderAndOrderItem
    {
        public int OrderItemId { get; set; }
        public OrderItem OrderItem { get; set; } = null!;

        [JsonIgnore]
        public int OrderId { get; set; }
    }
}