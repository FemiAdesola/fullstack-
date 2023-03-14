using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Product : BaseModel
    {
        public string Title { get; set; } = null!;
        public float Price { get; set; }
        public string Description { get; set; } = null!;

        [Column(TypeName = "jsonb")]
        public ICollection<string> Images { get; set; } = null!;

        [JsonIgnore]
        public int CategoryId { get; set; }

        public Category Category { get; set; } = default!;
    }
}