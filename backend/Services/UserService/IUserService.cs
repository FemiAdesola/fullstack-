using Backend.DTOs;
using Backend.Models;

namespace Backend.Services.UserService
{
    public interface IUserService
    {
        Task<User?> SignUpAsync(UserSignUpDTO request);
        Task<UserSignInResponseDTO?> SignInAsync(UserSignInDTO request);
        Task<User?> GetByIdAsync(int id);

        //Task<ICollection<User>> GetUsersAsync();
        Task<ICollection<User>> GetUsersAsync();
       

        Task<User> DeleteAsync(string Id);
        //Task<User?> FindByEmailAsync(string email);

        // Task<User?> FindByIdAsync(string Id);
    }
}