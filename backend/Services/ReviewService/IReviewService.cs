using Backend.DTOs;
using Backend.Models;
using Backend.Services.crude;

namespace Backend.Services.ReviewService
{

    public interface IReviewService : ICrudService<Review, ReviewDTO>
    {

    }
}