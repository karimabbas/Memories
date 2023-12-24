using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Models
{

    public enum ReactType
    {
        Love,
        Like
    }
    public class Reacts
    {
        public int Id { get; set; }
        public ReactType ReactTypeReact { get; set; }
        public ICollection<PostReacts>? PostReacts { get; set; }
        public AppUser? AppUser { get; set; }

    }
}