using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Dto;
using Server.Models;

namespace Server.Services
{
    public interface IPostService
    {
        List<Post> GetPosts();
        List<Post> GetUserPosts(string Id);
        bool CreatePost(Post post);
        Post EditPost(int id);
        Post UpadatePost(int id,PostDto postDto);
        bool Deletepost(int id);
    }
}