using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Data;
using Server.Models;
using Server.Services;

namespace Server.Controllers
{
    [Route("[controller]")]
    public class ReactsController : Controller
    {

        private readonly IReactsService _reactsService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DataContext _dataContext;

        public ReactsController(IReactsService reactsService, DataContext dataContext, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _reactsService = reactsService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _dataContext = dataContext;
        }


        [HttpPost("postreacts")]
        public IActionResult PostReact([FromQuery] int id, [FromQuery] string React)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            //    var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;

            // var user = _userManager.GetUserAsync(ClaimTypes.NameIdentifier);

            var user = _dataContext.AppUsers.Where(x => x.Email == userId).SingleOrDefault();
            Console.WriteLine(user);
            
            try
            {
                var NewReact = new Reacts
                {
                    AppUser = user
                };

                if (React == "Love")
                {
                    NewReact.ReactTypeReact = ReactType.Love;
                }
                if (React == "Like")
                    NewReact.ReactTypeReact = ReactType.Like;

                _reactsService.CreateReact(id, NewReact);
                return StatusCode(201, NewReact);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}