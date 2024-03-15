using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Services;

namespace Server.Repostoriy
{
    public class SecondNumberRepo : INumberService
    {
        public int GetNumber()
        {
            return 6;
        }
    }
}