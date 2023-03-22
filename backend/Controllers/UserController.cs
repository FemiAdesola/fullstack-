using AutoMapper;
using Backend.DTOs;
using Backend.Errors;
using Backend.Models;
using Backend.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Authorize]
    public class UserController : BaseApiController
    {
        private readonly IUserService _service;
        private readonly IUserTokenService _tokensService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;
        public UserController(
            IUserService service, 
            IMapper mapper, 
            IUserTokenService tokensService,
            IAuthorizationService authorizationService)
        {
            _service = service;
            _mapper = mapper;
            _tokensService = tokensService;
          _authorizationService = authorizationService;
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(UserSignUpDTO request)
        {
            var user = await _service.SignUpAsync(request);
            if (user is null)
            {
                return BadRequest();
            }
            return Ok(UserToReturnDTO.FromUser(user));
        }

        [AllowAnonymous]
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(UserSignInDTO request)
        {
            var response = await _service.SignInAsync(request);
            if (response is null)
            {
                return Unauthorized();
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<UserToReturnDTO>>> GetAll()
        {
            var user = await _service.GetUsersAsync();

            if (user is null)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<IReadOnlyList<UserToReturnDTO>>(user));
        }

        [HttpGet("{id}")]
        public async virtual Task<ActionResult<UserToReturnDTO?>> Get(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item is null)
            {
                return NotFound(new ApiResponseError(404));
            }
            return Ok(_mapper.Map<User, UserToReturnDTO>(item));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            var user= await _service.DeleteAsync(id);

            if (user is null)
            {
                return NotFound($" Item with ID {id} is not found");
            }
            return Ok(new { Message = $"item with Id {id} is deleted " });
        }

        [Authorize(Policy = "AdminOrOwner")]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<User>> Update(int id, UserUpdateDTO request)
        {
            var authorization = await _authorizationService.AuthorizeAsync(HttpContext.User, id, "AdminOrOwner");
            if (authorization.Succeeded)
            {
                var item = await _service.UpdateUserAsync(id, request);
                if (item is null)
                {
                    return NotFound(new ApiResponseError(404));
                }
                return Ok(item);
            }
            return Ok(authorization);
        }
    }
}

