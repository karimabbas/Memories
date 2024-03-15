using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Catengory_Name { get; set; }
        public Blog? Blog { get; set; }
        public ICollection<CateDesigner>? CateDesigners {get;set;}
    }
}