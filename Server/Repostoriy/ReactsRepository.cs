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
    public class ReactsRepository : IReactsService
    {
        private readonly DataContext _dataContext;
        public ReactsRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool CreateReact(int PostId, Reacts reacts)
        {

            var Posts_With_Reacts = _dataContext.PostReacts.AsNoTracking().ToHashSet();
            
            _dataContext.Add(reacts);

            var post = _dataContext.Posts.Where(x => x.Id == PostId).SingleOrDefault();

            if (post != null)
            {
                var NewPostReact = new PostReacts
                {
                    Post = post,
                    Reacts = reacts
                };

                _dataContext.Add(NewPostReact);
            }
            return _dataContext.SaveChanges() > 0 ? true : false;
        }
    }
}