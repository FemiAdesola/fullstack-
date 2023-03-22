using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Review : BaseModel
    {
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public User? User { get; set; }
    }
}