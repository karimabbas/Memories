using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Server.Data;
using Server.Models;
using Server.Services;

namespace Server.Repostoriy
{
    public class ActivityRepository : IActivityService
    {
        private readonly DataContext _dataContext;
        public ActivityRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool CreateActivity(Activity activity)
        {
            _dataContext.Add(activity);
            return _dataContext.SaveChanges() > 0 ? true : false;


        }

        public ICollection<Activity> GetAllActivities()
        {
            return _dataContext.Activity.AsNoTracking().ToHashSet();
        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0;
        }
    }
}