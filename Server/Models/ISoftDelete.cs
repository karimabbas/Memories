using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public interface ISoftDelete
    {
        public int ID {get;set;}
        public bool Deleted {get;set;}
    }
}