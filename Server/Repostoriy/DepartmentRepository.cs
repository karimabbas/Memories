using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
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

        public async Task<bool> DeleteDepatmet(int id)
        {
            var dept = await _dataContext.Departments.Where(x => x.Id == id).SingleAsync();
            if (dept is not null)
            {
                dept.IsDeleted = true;
                dept.DeletedAt = DateTimeOffset.UtcNow;
                _dataContext.Update(dept);
                return await _dataContext.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<List<Department>> Get_All_Dept()
        {
            return await _dataContext.Departments.AsNoTracking().ToListAsync();
        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0;
        }
    }
}