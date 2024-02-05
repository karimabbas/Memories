using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Server.Data;
using Server.Dto;
using Server.Models;
using Server.Services;
using StackExchange.Redis;

namespace Server.Repostoriy
{
    public class DriverRepository : IDriver<Driver>
    {
        private readonly DataContext _dataContext;
        private readonly IDistributedCache _distributedCache;
        public DriverRepository(DataContext dataContext, IDistributedCache distributedCache)
        {
            _dataContext = dataContext;
            _distributedCache = distributedCache;
        }

        public async Task<Driver> Create(Driver driver)
        {
            throw new NotImplementedException();

        }

        public Task<bool> Delete()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Driver>> GetAllDrivers()
        {
            throw new NotImplementedException();
        }
    }
}