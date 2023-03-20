using AutoMapper;
using Backend.DTOs;
using Backend.Models;
using Backend.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IUserTokenService _tokenUserService;
        private readonly IMapper _mapper;

        public UserService(UserManager<User> userManager,
            RoleManager<IdentityRole<int>> roleManager,
            IUserTokenService tokenUserService,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenUserService = tokenUserService;
            _mapper = mapper;
        }
        
        public async Task<User?> SignUpAsync(UserSignUpDTO request)
        {
            var user = _mapper.Map<UserSignUpDTO, User>(request);
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return null;
            }

            var userRoles = new[] { "Admin", "LoginUser" };
            foreach (var role in userRoles)
            {
                if (await _roleManager.FindByNameAsync(role) is null)
                {
                    await _roleManager.CreateAsync(new IdentityRole<int>
                    {
                        Name = role,
                    });
                }
            }
            await _userManager.AddToRolesAsync(user, userRoles);

            return user; 
        }

        public async Task<UserSignInResponseDTO?> SignInAsync(UserSignInDTO request)
        {

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                return null;
            }
            if (!await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return null;
            }
            return await _tokenUserService.GenerateUserTokenAsync(user);
        }

        public async Task<ICollection<User>> GetUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        public async Task<User> DeleteAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return null!;
            }
            await _userManager.DeleteAsync(user);
            return user;
        }

        public async Task<User> UpdateUserAsync(UserUpdateDTO request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                return null!;
            }
            if (!await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return null!;
            }
            if (request.NewPassword != null)
            {
                await _userManager.ChangePasswordAsync(user, request.Password, request.NewPassword);
            }
            request.UpdateUser(user);

            await _userManager.UpdateAsync(user);
            return user;

        }
    }
}