using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Server.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string? Blog_Name { get; set; }
        // public ICollection<Post>? Posts { get; set; }
        public ICollection<Category>? Categories { get; set; }
    }
}