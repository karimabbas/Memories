using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Services;

namespace Server.Repostoriy
{
    public class FirstNumberRepo : INumberService
    {
        public int GetNumber()
        {
           return 5 ;
        }
    }
}