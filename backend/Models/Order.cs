using System.Text.Json.Serialization;

namespace Backend.Models;

public class Order : BaseModel
{
    public bool IsPaid { get; set; }
    public DateTime DespatchDate { get; set; }
    public Address? Address { get; set; }
    
    [JsonIgnore]
    public int? AddressId { get; set; }
}