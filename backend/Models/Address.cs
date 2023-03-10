namespace Backend.Models;

public class Address : BaseModel
{
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Zipcode { get; set; } = null!;
    public string Country { get; set; } = null!;
}