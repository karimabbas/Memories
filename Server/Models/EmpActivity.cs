using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class EmpActivity
    {
        public int Id { get; set; }
        public int EmpID { get; set; }
        [ForeignKey("EmpID")]
        public Employee? Employee { get; set; }
        public int ActivityID { get; set; }
        [ForeignKey("ActivityID")]
        public Activity? Activity { get; set; }
    }
}