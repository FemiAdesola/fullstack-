using Backend.DTOs;
using Backend.Models;

namespace Backend.Services.UserService
{
    public interface IUserTokenService
    {
        Task<UserSignInResponseDTO> GenerateUserTokenAsync(User user);
    }
}