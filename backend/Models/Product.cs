using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class Product : BaseModel
{
    public string Title { get; set; } = null!;
    public float Price { get; set; }
    public string Description { get; set; } = null!;
    public ICollection<string> Images { get; set; } = null!;
    public Category Category { get; set; } = null!;
}