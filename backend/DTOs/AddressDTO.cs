namespace Backend.DTOs;

using Backend.Models;

public class AddressDTO : BaseDTO<Address>
{
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Zipcode { get; set; } = null!;
    public string Country { get; set; } = null!;

    public override void UpdateModel(Address model)
    {
        model.Street = Street;
        model.City = City;
        model.Zipcode = Zipcode;
        model.Country = Country;
    }
}