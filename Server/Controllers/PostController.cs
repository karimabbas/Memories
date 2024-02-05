using System.Net.Security;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.Dto;
using Server.Models;
using Server.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Client;

namespace Server.Controllers
{
    [ApiController]
    // [Route("api/[controller]")]
    public class PostController : ControllerBase
    {

        private readonly DataContext _dataContext;
        private readonly IPostService _postService;
        private readonly IWebHostEnvironment _webHostEnvironmen;
        public PostController(DataContext dataContext, IPostService postService, IWebHostEnvironment webHostEnvironment)
        {
            _dataContext = dataContext;
            _postService = postService;
            _webHostEnvironmen = webHostEnvironment;
        }

        [HttpPost("CreatePost")]
        public IActionResult CreatePost([FromForm] PostDto postDto)
        {

            if (postDto == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var uploads = Path.Combine(_webHostEnvironmen.WebRootPath, "PostFiles");
                var filePath = Path.Combine(uploads, postDto.formFile.FileName);
                using var filestream = new FileStream(filePath, FileMode.Create);
                postDto.formFile.CopyTo(filestream);

                var UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var user = _dataContext.Users.Where(x => x.Id == UserId).SingleOrDefault();

                var post = new Post
                {
                    AppUser = user,
                    Title = postDto.Title,
                    Message = postDto.Message,
                    PostImage = postDto.formFile?.FileName.ToString()
                };
                if (_postService.CreatePost(post))
                {
                    return StatusCode(201, post);
                }
                else
                {
                    ModelState.AddModelError("", "Something went wrong while saving");
                    return StatusCode(500, ModelState);
                }
            }
        }

        [HttpGet("GetAllPosts")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Post>))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetPosts()
        {
            // var UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var posts = _postService.GetPosts();
            if (posts != null)
            {
                return Ok(posts);
            }
            else
            {
                return StatusCode(500, "Server Errors, Values can not Fetching");
            }

        }
        [Authorize]
        [HttpDelete("DeletePost/{id}")]
        public IActionResult DeletePost(int id)
        {

            var post = _postService.Deletepost(id);
            if (post)
            {
                return StatusCode(200, "post Deleted Successfully");
            }
            else
            {
                return BadRequest("Post Not Found");
            }
        }

        [HttpGet("EditPost/{id}")]
        public ActionResult<Post> EditPost(int id)
        {
            var post = _postService.EditPost(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }


        [HttpPut("UpdatePost/{id}")]
        public ActionResult<Post> UpdatePost(int id, [FromForm] PostDto postDto)
        {
            if (postDto == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var UpdatePost = _postService.UpadatePost(id, postDto);
            if (UpdatePost != null)
            {
                return StatusCode(200, UpdatePost);
            }
            else
            {
                return BadRequest("Post Not Found");

            }
        }

        [HttpGet]
        [Route("GetUserPost")]
        public IActionResult GetUserPost([FromQuery]string id)
        {
            try
            {
                if (id != null)
                {
                    var post = _postService.GetUserPosts(id);
                    if (post != null)
                        return Ok(post);
                    return NoContent();
                }
                return BadRequest();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }
    }
}