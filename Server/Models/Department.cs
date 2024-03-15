using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string? Dept_name { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
        public DateTime YearOfCreation { get; set; }
        public ICollection<Employee>? Employees { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTimeOffset? DeletedAt { get; set; } = null;
        
    }
}