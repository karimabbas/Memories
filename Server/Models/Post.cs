using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is Requierd")]
        [MinLength(4, ErrorMessage = "Title should more than 4 characters")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Message is Requierd")]
        [MinLength(4, ErrorMessage = "Message should more than 4 characters")]
        public string? Message { get; set; }
        public string? PostImage { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime Created_At { get; set; }

        [ForeignKey("AppUser")]
        public string? User_Id { get; set; }
        public AppUser? AppUser { get; set; }
        public int Likes { get; set; }
        public int Loves { get; set; }

    }
}