using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.Dto;
using Server.Models;
using Server.Services;

namespace Server.Controllers
{
    [ApiController]
    // [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IDepartmentService _departmentService;
        public DepartmentController(DataContext dataContext, IDepartmentService departmentService)
        {
            _dataContext = dataContext;
            _departmentService = departmentService;
        }

        [HttpPost]
        [Route("department/create")]
        public IActionResult CreateDept([FromBody] DepartmentDto departmentDto)
        {
            if (departmentDto == null)
                return BadRequest();

            var dept = _departmentService.Get_All_Dept().Where(x => x.Dept_name == departmentDto.Dept_name).FirstOrDefault();
            if (dept != null)
            {
                ModelState.AddModelError("", "Dept is already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dept is Invalid" });
            }
            else
            {
                var department = new Department
                {
                    Dept_name = departmentDto.Dept_name,
                    YearOfCreation = departmentDto.YearOfCreation,
                };
                try
                {
                    _departmentService.CreateDepartment(department);
                    return StatusCode(201, department);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                    // return StatusCode(500, new { message = "Something Wrong on server when saving,Try again." });
                }

            }
        }

        [Authorize]
        [HttpGet("department/all")]
        public IActionResult AllDepts()
        {
            try
            {
                var result = _departmentService.Get_All_Dept();
                if (result != null)
                {
                    return Ok(result);

                }
                return BadRequest(new { message = "Server Error in Get all Depts]" });

            }
            catch (System.Exception ex)
            {
                return Ok(new { message = ex.Message });

            }
        }
    }
}