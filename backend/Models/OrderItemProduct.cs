using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class OrderItemProduct
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        [JsonIgnore]
        public int OrderItemId { get; set; }
    }
}