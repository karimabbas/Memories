using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Dto
{
    public class UserDto
    {
        // [Required(ErrorMessage = "First Name Fie is Requierd")]
        [RegularExpression("^[a-zA-Z0-9_ ]*$")]
        public string? FirstName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string Password { get; set; }
        // [Compare("Password", ErrorMessage = "Passord mismatch")]
        public string ConfirmPassword { get; set; }
        public ICollection<Post>? Posts { get; set; }

    }
}