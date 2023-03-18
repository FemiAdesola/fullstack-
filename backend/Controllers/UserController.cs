using AutoMapper;
using Backend.DTOs;
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
        public async Task<IActionResult> GetAll()
        {
            var user = await _service.GetAllAsync();

            if (user is null)
            {
                return BadRequest();
            }
            return Ok(user);
        }


        // [AllowAnonymous]
        // [HttpGet]
        // public async Task<IActionResult> GetAll(UserToReturnDTO request)
        // {

        //     // var user = _mapper.Map<UserToReturnDTO, User>(request);
        //     var result = await _service.GetAllAsync(request);
        //     if (result is null)
        //     {
        //         return BadRequest();
        //     }
        //     return Ok(result);
        //     //return Ok(UserToReturnDTO.FromUser((User)result));

        //     // return Ok(_mapper.Map<IReadOnlyList<User>, IReadOnlyList<UserToReturnDTO>>(result));
        // }
    }

}

