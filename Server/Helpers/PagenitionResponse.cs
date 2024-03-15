using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Helpers
{
    public class PagenitionResponse
    {
        public int? TotlaCount {get;set;}
        public int? TotlaPage {get;set;}
        public int? CurrentPage {get;set;}
        public int? PageSize {get;set;}
        public List<Employee>? Employees {get;set;}
    }
}