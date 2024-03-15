using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Services;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NumbersController : ControllerBase
    {
        private readonly IEnumerable<INumberService> _numberService;

        public NumbersController(IEnumerable<INumberService> numberService)
        {
            _numberService = numberService;
        }
        [HttpGet]
        public IActionResult Numbers()
        {
            return Ok(_numberService.Sum(x => x.GetNumber()));
        }
    }
}