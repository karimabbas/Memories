using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Dto
{
    public class PostDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is Requierd")]
        [MinLength(4, ErrorMessage = "Title should more than 4 characters")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Message is Requierd")]
        [MinLength(4, ErrorMessage = "Message should more than 4 characters")]
        public string? Message { get; set; }
        [Required(ErrorMessage = "File is Requierd")]
        public IFormFile? formFile { get; set; }
    }
}