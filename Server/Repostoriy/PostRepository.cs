using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using Server.Data;
using Server.Dto;
using Server.Models;
using Server.Services;

namespace Server.Repostoriy
{
    public class PostRepository : IPostService
    {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PostRepository(DataContext dataContext, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _dataContext = dataContext;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }
        public bool CreatePost(Post post)
        {
            _dataContext.Add(post);
            return _dataContext.SaveChanges() > 0 ? true : false;

        }

        public bool Deletepost(int id)
        {
            var post = _dataContext.Posts.Find(id);
            if (post != null)
            {
                _dataContext.Remove(post);
                return _dataContext.SaveChanges() > 0 ? true : false;
            }
            else
            {
                return false;
            }
        }

        public List<Post> GetPosts()
        {
            //usign Dapper

            // using (var conn = new SqlConnection(_configuration.GetConnectionString("myConn")))
            // {
            //     var posts = conn.Query<Post>("SELECT * FROM posts").ToList();
            // }
            return _dataContext.Posts.AsNoTracking().ToList();
        }

        public Post EditPost(int id)
        {
            var post = _dataContext.Posts.Find(id);
            if (post != null)
            {
                return post;
            }
            else
            {
                return NotFound();
            }
        }

        public Post UpadatePost(int id, PostDto postDto)
        {
            var postDB = _dataContext.Posts.Find(id);
            if (postDB != null)
            {

                var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "PostFiles");
                var filePath = Path.Combine(uploads, postDto.formFile.FileName);
                using var filestream = new FileStream(filePath, FileMode.Create);
                postDto.formFile.CopyTo(filestream);

                postDB.Title = postDto.Title;
                postDB.Message = postDto.Message;
                postDB.PostImage = postDto.formFile?.ToString();

                _dataContext.Update(postDB);
                _dataContext.SaveChanges();
                return postDB;

            }
            else
            {
                return NotFound();
            }
        }

        private Post NotFound()
        {
            throw new NotImplementedException();
        }

        public List<Post> GetUserPosts(string id)
        {
            var user = _dataContext.Users.Find(id);
            return _dataContext.Posts.Where(x => x.AppUser.Id == user.Id).AsNoTracking().ToList();
        }
    }
}