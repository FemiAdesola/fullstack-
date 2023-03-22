using System.IdentityModel.Tokens.Jwt;
using Backend.DTOs;
using Backend.Models;

namespace Backend.Services.UserService
{
    public interface IUserTokenService
    {
        Task<UserSignInResponseDTO> GenerateUserTokenAsync(User user);
        JwtSecurityToken GetToken(string token);
    }
}