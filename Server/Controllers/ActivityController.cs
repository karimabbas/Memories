using System.Reflection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Dto;
using Server.Services;
using Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Server.Controllers
{
    [Route("[controller]")]
    public class ActivityController : Controller
    {
        private readonly IActivityService _activityService;
        private readonly IMapper _mapper;
        public ActivityController(IActivityService activityService, IMapper mapper)
        {
            _activityService = activityService;
            _mapper = mapper;

        }

        [HttpPost("Create")]
        public IActionResult CreateActivity([FromBody] ActivityDto activityDto)
        {

            if (activityDto == null)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Activity From is Invalid" });
            }

            var act = _mapper.Map<Models.Activity>(activityDto);

            if (_activityService.CreateActivity(act))
            {
                return StatusCode(201, act);
            }
            else
            {
                ModelState.AddModelError("", "Some thing Wrong when saving ");
                return StatusCode(500, ModelState);
            }

        }

        // [Authorize]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("All")]
        public IActionResult AllActivities()
        {
            try
            {
                var result = _activityService.GetAllActivities();
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest(new { message = "Server error occured when fetch data" });
            }
            catch (System.Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }

    }
}