using AutoMapper;
using Backend.DTOs;
using Backend.Models;
using Backend.Services.Interface;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Controllers
{
    public class ReviewController : CrudController<Review, ReviewDTO, ReviewToReturnDTO>
    {
        private readonly IReviewService _reviewService;
        private readonly ILogger<ReviewController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;

        public ReviewController(
            IReviewService service, 
            ILogger<ReviewController> logger,
            IMapper mapper,
            IAuthorizationService authorizationService
            ) : base(service, mapper, authorizationService)
        {
            _reviewService = service;
            _logger = logger;
            _mapper = mapper;
            _authorizationService = authorizationService;
        }
    }
}