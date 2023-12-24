using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Dto
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string? Dept_name { get; set; }
        public DateTime YearOfCreation { get; set; }
    }
}