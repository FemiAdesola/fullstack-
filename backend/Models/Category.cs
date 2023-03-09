using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public  class Category : BaseModel
{
    public string Name { get; set; } = null!;
    
    [Column(TypeName = "bytea")]
    public string Image { get; set; } = null!;

    internal void UpdateModel(Category category)
    {
        throw new NotImplementedException();
    }
}
