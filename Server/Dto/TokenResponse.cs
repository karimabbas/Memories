using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Dto
{
    public class TokenResponse
    {

        [Required]
        public string? Token { get; set; }
        [Required]
        public RefreshToken? RefreshToken { get; set; }
        public DateTime? TokenExpiry {get;set;}
        public string? Message { get; set; }

    }
}