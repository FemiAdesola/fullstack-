using AutoMapper;
using Backend.DTOs;
using Backend.Errors;
using Backend.Models;
using Backend.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    // [Authorize]
    public class UserController : BaseApiController
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
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

        [AllowAnonymous]
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {

            var user= await _service.DeleteAsync(id);

            if (user is null)
            {
                return NotFound($" Item with ID {id} is not found");
            }
            return Ok(new { Message = $"item with Id {id} is deleted " });
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
    }
}

