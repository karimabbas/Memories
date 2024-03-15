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
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None, Duration = 0)]
    public class DepartmentController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IDepartmentService _departmentService;
        public DepartmentController(DataContext dataContext, ILogger<EmployeeController> logger, IDepartmentService departmentService)
        {
            _dataContext = dataContext;
            _departmentService = departmentService;
            _logger = logger;
        }

        [HttpPost]
        [Route("department/create")]
        public IActionResult CreateDept([FromBody] DepartmentDto departmentDto)
        {
            if (departmentDto == null)
                return BadRequest();

            // var dept = _departmentService.Get_All_Dept().Where(x => x.Dept_name == departmentDto.Dept_name).FirstOrDefault();
            // if (dept != null)
            // {
            //     ModelState.AddModelError("", "Dept is already exists");
            //     return StatusCode(422, ModelState);
            // }

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

        // [Authorize]
        [HttpGet("department")]
        public async Task<IActionResult> AllDepts()
        {
            try
            {
                var result = await _departmentService.Get_All_Dept();
                if (result != null)
                {
                    return Ok(result);
                }
                _logger.LogError("You not authorize to this action");
                return BadRequest(new { message = "Server Error in Get all Depts]" });

            }
            catch (System.Exception ex)
            {
                return Ok(new { message = ex.Message });

            }
        }

        [HttpDelete("Department{DeptId}")]
        public async Task<IActionResult> DeleteDepartment([FromRoute] int DeptId)
        {
            try
            {
                var result = await _departmentService.DeleteDepatmet(DeptId);
                if (result)
                {
                    return Ok("Depatment Deleted Successfully");
                }
                return NotFound("Faild to Delete department");
            }
            catch (System.Exception ex)
            {
                return Ok(new { message = ex.Message });

            }
        }
    }
}