using Backend.Models;

namespace Backend.DTOs
{
    public class OrderDTO : BaseDTO<Order>
    {
        public bool IsPaid { get; set; }
        public double TotalPrice { get; set; }
        public DateTime DispatcedDate { get; set; }
        public AddressDTO Address { get; set; } = null!;
        public int UserId { get; set; }

        public override void UpdateModel(Order model)
        {
            model.IsPaid = IsPaid;
            model.DispatchedDate = DispatcedDate;
            model.TotalPrice = TotalPrice;
          
            model.UserId = UserId;

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

    public class OrderToReturnDTO : BaseReturnDTO<Order>
    {
        public double TotalPrice { get; set; }
        public AddressDTO Address { get; set; } = null!;
        public ICollection<OrderAndOrderItem> Orders { get; set; } = null!;
        public int UserId { get; set; }
        public override void BaseToRetunModel(Order returnBase)
        {
            returnBase.TotalPrice = TotalPrice;
            returnBase.UserId = UserId;

            if (returnBase.Address is not null)
            {
                Address.UpdateModel(returnBase.Address);
            }
            else
            {
                var address = new Address();
                Address.UpdateModel(address);
                returnBase.Address = address;
            }
        }
    }
}