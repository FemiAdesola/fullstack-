using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class UserSignInDTO
    {
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

    public class UserSignInResponseDTO
    {
        public string Token { get; set; } = null!;
        public DateTime Expiration { get; set; }
    }
}