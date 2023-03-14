using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.DTOs
{
    public class OrderDTO : BaseDTO<Order>
    {
        public bool IsPaid { get; set; }
        public double TotalPrice { get; set; }
        public DateTime DispatcedDate { get; set; }
        public AddressDTO Address { get; set; } = null!;

        public override void UpdateModel(Order model)
        {
            model.IsPaid = IsPaid;
            model.DispatchedDate = DispatcedDate;
            model.TotalPrice = TotalPrice;

            if (model.Address is not null)
            {
                Address.UpdateModel(model.Address);
            }
            else
            {
                var address = new Address();
                Address.UpdateModel(address);
                model.Address = address;
            }
        }
    }
}