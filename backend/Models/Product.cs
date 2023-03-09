using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models;

public class Product : BaseModel
{
    public string Title { get; set; } = null!;
    public float Price { get; set; }
    public string Description { get; set; } = null!;

    
    [JsonIgnore]
    public int CategoryId { get; set; } 

    public Category Category { get; set; } = null!;
    
    [Column(TypeName = "jsonb")]
    public ICollection<string> Images { get; set; } = null!;
}