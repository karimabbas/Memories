using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Activity
    {
        public int Id {get;set;}
        public string? Activity_name {get;set;}
        public ICollection<EmpActivity>? EmpActivities {get;set;}

    }
}