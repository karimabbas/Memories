using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;
using Server.Services;

namespace Server.Repostoriy
{
    public class DepartmentRepository : IDepartmentService
    {
        private readonly DataContext _dataContext;
        public DepartmentRepository(DataContext dataContext)
        {
            _dataContext = dataContext;

        }
        public bool CreateDepartment(Department department)
        {
            _dataContext.Add(department);
            return Save();
        }
        public List<Department> Get_All_Dept()
        {
            return _dataContext.Departments.ToList();
        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0;
        }
    }
}