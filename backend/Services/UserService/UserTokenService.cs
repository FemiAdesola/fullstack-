using System.Security.Claims;
using Backend.DTOs;
using Backend.Models;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Backend.Services.UserService
{
    public class UserTokenService : IUserTokenService
    {
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;

        public UserTokenService(IConfiguration config, UserManager<User> userManager)
        {
            _config = config;
            _userManager = userManager;
        }

        public async Task<UserSignInResponseDTO> GenerateUserTokenAsync(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.Name, user.UserName!),
            };

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var secret = _config["AppSettings:Secret"];
            var signingKey = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret!)),
                SecurityAlgorithms.HmacSha256
            );

            var expiration = DateTime.Now.AddHours(1);

            var token = new JwtSecurityToken(
                _config["AppSettings:Issuer"],
                _config["AppSettings:Audience"],
                claims,
                expires: expiration,
                signingCredentials: signingKey
            );
            var tokenWriter = new JwtSecurityTokenHandler();

            return new UserSignInResponseDTO
            {
                Token = tokenWriter.WriteToken(token),
                Expiration = expiration,
            };
        }
    }
}