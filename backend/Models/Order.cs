using System.Text.Json.Serialization;

namespace Backend.Models;

public class Order : BaseModel
{
    public bool IsPaid { get; set; }
    public double TotalPrice { get; set; }
    public DateTime DispatchedDate { get; set; }
    public Address? Address { get; set; }
    
    [JsonIgnore]
    public int? AddressId { get; set; }
}