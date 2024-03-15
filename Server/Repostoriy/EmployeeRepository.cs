using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Dto;
using Server.Models;
using Server.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Mvc;

namespace Server.Repostoriy
{
    public class EmployeeRepository : IGlobalService<Employee>
    {
        private readonly DataContext _dataContext;
        private readonly IMemoryCache _memoryCache;
        public EmployeeRepository(DataContext dataContext, IMemoryCache memoryCache)
        {
            _dataContext = dataContext;
            _memoryCache = memoryCache;
        }

        public bool Create(int deptId, Employee t)
        {
            var dept = _dataContext.Departments.Where(x => x.Id == deptId).SingleOrDefault();
            if (dept != null)
                t.Department = dept;

            _dataContext.Add(t);
            return _dataContext.SaveChanges() > 0;
        }

        public bool DELETE(int id)
        {
            var emp = _dataContext.Employees.Find(id);
            if (emp != null)
                _dataContext.Remove(emp);
            return _dataContext.SaveChanges() > 0;

        }

        public async Task<List<Employee>> GetAll()
        {
            var data = _memoryCache.Get<List<Employee>>("allemps");
            if (data is not null)
            {
                return data;
            }
            var expirtionDate = DateTimeOffset.Now.AddMinutes(5.0);
            data = await _dataContext.Employees.AsNoTracking().Include(x => x.Department).ToListAsync();
            _memoryCache.Set("allemps", data, expirtionDate);

            return data;

            //using Stored_PRocdure
            // return _dataContext.Employees.FromSql($"AllEmployee").ToList();
        }

        public IQueryable<Employee> GetAllExceptId()
        {
            return _dataContext.Employees.Where(x => x.Id >= 120).Take(10); ;
        }
        public IEnumerable<Employee> GetAllExceptName()
        {
            var employees = from emp in _dataContext.Employees
                            where emp.Id >= 120
                            select emp;
            return employees;
        }
        public Employee GetById(int EmpID)
        {
            return _dataContext.Employees.Where(x => x.Id == EmpID).Include(x => x.Department).Single();
            // .Include(x => x.EmpActivities)
            // .ThenInclude(x=>x.Activity)
            // .AsEnumerable().First();

            ///Stored Procedure
            // return _dataContext.Employees.FromSqlRaw("EXECUTE spEmpWithACtivity {0}", EmpID).AsEnumerable().First();
        }

        public async Task<List<Employee>> GetEmpByDeptId(int id)
        {
            var dept = await _dataContext.Departments.FindAsync(id);
            return await _dataContext.Employees.AsNoTracking().Where(x => x.Department.Id == id).ToListAsync();
        }

        public Employee Upadate(int id, EmployeeDto t)
        {
            var Emp = GetById(id);

            var dept = _dataContext.Departments.Where(x => x.Id == t.Department).Single();

            Emp.Name = t.Name;
            Emp.Email = t.Email;
            Emp.Salary = t.Salary;
            Emp.Age = t.Age;
            Emp.Department = dept;

            _dataContext.Update(Emp);
            _dataContext.SaveChanges();

            return Emp;

        }
    }
}