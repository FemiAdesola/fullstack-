using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class Product : BaseModel
    {
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;

        [Column(TypeName = "bytea")]
         public string Images { get; set; } = null!;

        [JsonIgnore]
        public int CategoryId { get; set; }

        public Category Category { get; set; } = default!;

        [JsonIgnore]
        public ICollection<ReviewProduct> Reviews { get; set; } = null!;

    }
}