using Backend.Models;

namespace Backend.DTOs
{
    public class AddReviewToProductDTO
    {
        public int ReviewId { get; set; }
        // public ICollection<Review> Reviews { get; set; } = null!;
        public int UserId { get; set; }
    }
}