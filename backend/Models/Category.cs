using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{

    public class Category : BaseModel
    {
        public string Name { get; set; } = null!;

        [Column(TypeName = "bytea")]
        public string Image { get; set; } = null!;
    }
}