using System.Runtime.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.Dto;
using Server.Helpers;
using Server.Models;
using Server.Services;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Server.Controllers
{
    [ApiController]
    // [Route("api/[c")]
    public class AccountController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUserService _userService;
        private readonly JwtService _jwtService;
        public AccountController(JwtService jwtService, DataContext dataContext, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IUserService userService)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost("Account/SginUp")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            var userDB = _dataContext.Users.FirstOrDefault(x => x.Email == userDto.Email);
            if (userDB != null)
            {
                return Ok(new { message = "User Is already Registerd Before" });
            }
            var newUser = new AppUser
            {
                UserName = userDto.FirstName,
                Email = userDto.Email,
            };
            var result = await _userManager.CreateAsync(newUser, userDto.Password);
            if (result.Succeeded)
            {
                return Ok(new { message = newUser });
            }
            return BadRequest(new { message = result.Errors });
        }

        [HttpPost("Account/Sginin")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> SginIn([FromBody] UserDto userDto)
        {
            var user = await _userManager.FindByEmailAsync(userDto.Email);

            var password = await _userManager.CheckPasswordAsync(user, userDto.Password);
            if (password)
            {
                var result = await _signInManager.PasswordSignInAsync(user, userDto.Password, false, false);
                if (result.Succeeded)
                {
                    var GenerateToken = _jwtService.GenerateToken();

                    Response.Cookies.Append("GenerateToken", GenerateToken, new CookieOptions
                    {
                        HttpOnly = true
                    });
                    return Ok(new { message = user, Token = GenerateToken });
                }
                return BadRequest(new { message = "Error, Not Correct" });
            }
            return BadRequest(new { message = "Error Wrong Password" });
        }


        [HttpGet("Account/Logout")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Logout()
        {
            try
            {
                Response.Cookies.Delete("GenerateToken");
                await _signInManager.SignOutAsync();
                return Ok(new { message = "User Loged out" });

            }
            catch (System.Exception ex)
            {
                return Ok(new { message = ex.Message });

            }
        }

        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize]
        [HttpGet("AllUsers")]
        [ProducesResponseType(200)]
        public ActionResult<List<AppUser>> GetAllUsers()
        {

            string token = Request.Headers["Authorization"];
            if (token.StartsWith("Bearer"))
            {
                token = token.Substring("Bearer".Length).Trim();
            }

            var handler = new JwtSecurityTokenHandler();

            try
            {
                var result = _userService.GetAllUsers();
                if (result != null)
                {
                    return Ok(new { message = result });

                }
                return BadRequest(new { message = "Server Error in Get all Users" });

            }
            catch (System.Exception ex)
            {
                return Ok(new { message = ex.Message });

            }
        }


    }
}