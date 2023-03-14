using Backend.DTOs;
using Backend.Models;
using Backend.Services.ReviewService;

namespace Backend.Controllers
{
    public class ReviewController : CrudController<Review, ReviewDTO>
    {
        private readonly IReviewService _reviewService;
        private readonly ILogger<ReviewController> _logger;

        public ReviewController(IReviewService service, ILogger<ReviewController> logger) : base(service)
        {
            _reviewService = service;
            _logger = logger;
        }
    }
}