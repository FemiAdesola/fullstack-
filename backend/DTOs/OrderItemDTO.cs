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

    public class OrderItemToReturnDTO : BaseReturnDTO<OrderItem>
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public ICollection<OrderItemProduct> ProductLists { get; set; } = null!;
        public override void BaseToRetunModel(OrderItem returnBase)
        {
            returnBase.Id = Id;
            returnBase.Quantity = Quantity;
        
        }
    }
}