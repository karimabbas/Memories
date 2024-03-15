using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Migrations;
using Server.Dto;
using Server.Models;

namespace Server.Services
{
    public interface IGlobalService<T>
    {
        Task<List<T>> GetAll();
        IEnumerable<T> GetAllExceptName();
        IQueryable<T> GetAllExceptId();
        bool Create(int id,T t);
        T GetById(int id);
        bool DELETE(int id);
        T Upadate(int id,EmployeeDto t);
        Task<List<T>> GetEmpByDeptId(int id);

    }
}