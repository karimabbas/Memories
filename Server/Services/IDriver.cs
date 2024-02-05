using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Dto;
using Server.Models;

namespace Server.Services
{
    public interface IDriver<T>
    {
        Task<IEnumerable<T>> GetAllDrivers();
        Task<T> Create(Driver driver);
        Task<bool> Delete();
    }
}