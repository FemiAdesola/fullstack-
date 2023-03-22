using Backend.Models;

namespace Backend.DTOs
{
    public class AddReviewToProductDTO
    {
        public int ReviewId { get; set; }
        public int UserId { get; set; }
    }
}