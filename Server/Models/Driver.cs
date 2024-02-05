using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string? DriverName { get; set; }
        public string? LicenseID { get; set; }
        public string? CarType { get; set; }
    }
}