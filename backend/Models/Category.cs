namespace Backend.Models;

using System.ComponentModel.DataAnnotations.Schema;

public  class Category : BaseModel
{
    public string Name { get; set; } = null!;
    
    [Column(TypeName = "bytea")]
    public string Image { get; set; } = null!;
}
