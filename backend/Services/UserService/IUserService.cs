using Backend.DTOs;
using Backend.Models;

namespace Backend.Services.UserService
{
    public interface IUserService
    {
        Task<User?> SignUpAsync(UserSignUpDTO request);
        Task<UserSignInResponseDTO?> SignInAsync(UserSignInDTO request);
        Task<ICollection<User>> GetAllAsync();
        // Task<ICollection<User>> GetAllAsync(UserToReturnDTO request);
    }
}