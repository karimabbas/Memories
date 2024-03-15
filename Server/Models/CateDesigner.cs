using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class CateDesigner
    {
        public int Id { get; set; }
        [ForeignKey("Category_id")]
        public Category? Categories { get; set; }
        [ForeignKey("Desginer_id")]
        public Desginer? Desginers { get; set; }
    }
}