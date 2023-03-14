using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class OrderItem : BaseModel
    {
        public int Quantity { get; set; }
        public ICollection<OrderItemProduct> ProductLists { get; set; } = null!;
    }
}