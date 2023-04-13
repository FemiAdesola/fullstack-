using AutoMapper;
using Backend.DTOs;
using Backend.Models;
using Backend.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Controllers
{
    [Route("api/v1/categories")]
    public class CategoryController : CrudController<Category, CategoryDTO, CategoryToReturnDTO>
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;

        public CategoryController(
            ICategoryService service, 
            ILogger<CategoryController> logger, 
            IMapper mapper,
            IAuthorizationService authorizationService
            ) : base(service, mapper, authorizationService)
        {
            _categoryService = service;
            _logger = logger;
            _mapper = mapper;
            _authorizationService = authorizationService;
        }
    }
}