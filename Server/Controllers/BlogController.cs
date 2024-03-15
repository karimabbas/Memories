using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Services;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IGlobalService<Blog> _globalService;
        public BlogController(IGlobalService<Blog> globalService)
        {
            _globalService = globalService;
        }

        [HttpDelete("Blog/{id}")]
        public IActionResult DeleteBlog([FromRoute] int id)
        {
            try
            {
                var result = _globalService.DELETE(id);
                if (result)
                {
                    return Ok("Blog Deleted Successfully");
                }
                return NotFound("Faild to Delete");
            }
            catch (System.Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }
    }
}