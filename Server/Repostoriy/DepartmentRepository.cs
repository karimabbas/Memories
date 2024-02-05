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
        private readonly IDistributedCache _distributedCache;
        public DepartmentRepository(DataContext dataContext, IDistributedCache distributedCache)
        {
            _dataContext = dataContext;
            _distributedCache = distributedCache;

        }
        public bool CreateDepartment(Department department)
        {
            _dataContext.Add(department);
            return Save();
        }
        public async Task<List<Department>> Get_All_Dept()
        {
            var cachedData = await _distributedCache.GetStringAsync("allDepts");
            if (cachedData is not null)
            {
                return JsonConvert.DeserializeObject<List<Department>>(cachedData);
            }

            var expirationTime = TimeSpan.FromMinutes(5.0);
            var allDepartments = await _dataContext.Departments.ToListAsync();
            cachedData = JsonConvert.SerializeObject(allDepartments);
            var cacheOptions = new DistributedCacheEntryOptions().SetAbsoluteExpiration(expirationTime);
            await _distributedCache.SetStringAsync("allDepts", cachedData, cacheOptions);
            
            return allDepartments;
        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0;
        }
    }
}