using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;
using Server.Services;

namespace Server.Repostoriy
{
    public class UserRepository : IUserService
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public AppUser Cuttent_user(string id)
        {
            var user = _dataContext.Users.Where(x => x.Id == id).SingleOrDefault();
            return user;
        }

        public List<AppUser> GetAllUsers()
        {
            return _dataContext.Users.ToList();
        }
    }
}