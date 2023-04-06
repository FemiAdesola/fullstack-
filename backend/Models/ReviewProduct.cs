using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class ReviewProduct
    {
        [JsonIgnore]
        public int ReviewId { get; set; }
        public Review Review { get; set; } = null!;

        [JsonIgnore]
        public int ProductId { get; set; }
    }
}