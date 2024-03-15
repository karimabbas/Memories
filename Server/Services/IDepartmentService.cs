using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Services
{
    public interface IDepartmentService
    {
        Task<List<Department>> Get_All_Dept();
        bool CreateDepartment(Department department);
        Task<bool> DeleteDepatmet(int id);

    }
}