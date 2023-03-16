using AutoMapper;
using Backend.DTOs;
using Backend.Models;
using Backend.Services.Interface;

namespace Backend.Controllers
{
    public class ReviewController : CrudController<Review, ReviewDTO, ReviewToReturnDTO>
    {
        private readonly IReviewService _reviewService;
        private readonly ILogger<ReviewController> _logger;
        private readonly IMapper _mapper;

        public ReviewController(IReviewService service, 
            ILogger<ReviewController> logger, IMapper mapper) 
            : base(service, mapper)
        {
            _reviewService = service;
            _logger = logger;
            _mapper = mapper;
        }
    }
}