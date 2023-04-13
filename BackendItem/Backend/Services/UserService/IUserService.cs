using Backend.DTOs;
using Backend.Models;

namespace Backend.Services.UserService
{
    public interface IUserService
    {
        Task<User?> SignUpAsync(UserSignUpDTO request);
        Task<UserSignInResponseDTO?> SignInAsync(UserSignInDTO request);
        Task<User?> GetByIdAsync(int id);
        Task<ICollection<User>> GetUsersAsync();
        Task<User> UpdateUserAsync(int id, UserUpdateDTO request);
        Task<User> DeleteAsync(int id);
    }
}