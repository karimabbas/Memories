using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? Token { get; set; }
        public string? JwtId { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime AddedDate { get; set; } = DateTime.UtcNow;
        public DateTime ExpireDate { get; set; }
        [ForeignKey("UserId")]
        public AppUser? AppUser { get; set; }
    }
}