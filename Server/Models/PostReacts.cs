using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class PostReacts
    {
        public int Id {get;set;}
        public int Likes {get;set;}
        public int Loves {get;set;}
        public int Post_id {get;set;}
        public Post? Post {get;set;}

    }
}