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
    public class EmployeeRepository : IGlobalService<Employee>
    {
        private readonly DataContext _dataContext;
        public EmployeeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool Create(int deptId, Employee t)
        {
            var dept = _dataContext.Departments.Where(x => x.Id == deptId).SingleOrDefault();
            if (dept != null)
                t.Department = dept;

            _dataContext.Add(t);
            return _dataContext.SaveChanges() > 0 ? true : false;
        }

        public List<Employee> GetAll()
        {
            return _dataContext.Employees.AsNoTracking().Include(x=>x.Department).ToList();
        }
    }
}