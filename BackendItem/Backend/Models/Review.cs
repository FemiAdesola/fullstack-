using System.Text.Json.Serialization;

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