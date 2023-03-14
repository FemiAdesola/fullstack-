using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.DTOs
{
    public class OrderItemDTO : BaseDTO<OrderItem>
    {
        public int Quantity { get; set; }

        public override void UpdateModel(OrderItem model)
        {
            model.Quantity = Quantity;
        }
    }
}