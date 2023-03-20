using Backend.Models;

namespace Backend.DTOs
{
    public class UserUpdateDTO : UserSignUpDTO
    {
        public string? NewPassword { get; set; }

        public void UpdateUser(User user)
        {
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.UserName = UserName;
            user.Email = Email;
            user.Avatar = Avatar;
        }
    }
}