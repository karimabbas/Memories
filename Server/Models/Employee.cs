using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double? Salary { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public int? Age { get; set; }
        public Department? Department { get; set; }
        public ICollection<EmpActivity>? EmpActivities {get;set;}


    }
}