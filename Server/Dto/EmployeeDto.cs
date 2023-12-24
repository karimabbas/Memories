using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double? Salary { get; set; }
        public string? Email { get; set; }
        public int? Age { get; set; }
        public int Department { get; set; }
    }
}