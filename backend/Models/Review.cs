using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Review : BaseModel
    {
        public int Rating { get; set; }
        public string? Comment { get; set; }
        // public int ProductId { get; set; }
        // public ICollection<ReviewProduct> ReviewLists { get; set; } = null!;
    }
}