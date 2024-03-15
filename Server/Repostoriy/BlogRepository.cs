using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Dto;
using Server.Models;
using Server.Services;

namespace Server.Repostoriy
{
    public class BlogRepository : IGlobalService<Blog>
    {
        private readonly DataContext _dataContext;
        public BlogRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool Create(int id, Blog t)
        {
            throw new NotImplementedException();
        }

        public bool DELETE(int id)
        {
            var blog = _dataContext.Blogs.Where(b => b.Id == id).SingleOrDefault();
            if (blog is not null)
            {
                _dataContext.Remove(blog);
                return _dataContext.SaveChanges() > 0;
            }
            return false;
        }

        public Task<List<Blog>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Blog> GetAllExceptId()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Blog> GetAllExceptName()
        {
            throw new NotImplementedException();
        }

        public Blog GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Blog>> GetEmpByDeptId(int id)
        {
            throw new NotImplementedException();
        }

        public Blog Upadate(int id, EmployeeDto t)
        {
            throw new NotImplementedException();
        }
    }
}