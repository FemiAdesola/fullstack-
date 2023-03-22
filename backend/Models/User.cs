using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Backend.Models
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        [Column(TypeName = "bytea")]
        public string Avatar { get; set; } = null!;
    }
}