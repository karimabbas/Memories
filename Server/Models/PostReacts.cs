using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class PostReacts
    {
        public int Id { get; set; }
        public Post? Post { get; set; }
        public Reacts? Reacts { get; set; }

    }
}