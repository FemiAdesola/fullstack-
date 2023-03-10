namespace Backend.DTOs;

using Backend.Models;

public class OrderDTO : BaseDTO<Order>
{
    public bool IsPaid { get; set; }
    public DateTime DespatchDate { get; set; }
    public AddressDTO Address { get; set; } = null!;

    public override void UpdateModel(Order model)
    {
        model.IsPaid = IsPaid;
        model.DespatchDate = DespatchDate;

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