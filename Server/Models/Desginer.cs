using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Desginer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<CateDesigner>? CateDesigners { get; set; }

    }
}