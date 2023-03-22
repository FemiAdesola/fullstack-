using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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

        //public int UserId { get; set; }
        // public User User { get; set; }
    }
}