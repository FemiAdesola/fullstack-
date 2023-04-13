using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class Order : BaseModel
    {
        public bool IsPaid { get; set; }
        public double TotalPrice { get; set; }
        public DateTime DispatchedDate { get; set; }
        public Address? Address { get; set; }

        [JsonIgnore]
        public int? AddressId { get; set; }

        [JsonIgnore]
        public ICollection<OrderAndOrderItem> Orders { get; set; } = null!;

        public int UserId { get; set; }
        
        [JsonIgnore]
        public User? User { get; set; }
    }
}