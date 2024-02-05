using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Dto;
using Server.Models;
using Server.Services;

namespace Server.Controllers
{
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IGlobalService<Employee> _globalServiceEmp;
        private readonly IMapper _mapper;
        public EmployeeController(ILogger<EmployeeController> logger, IMapper mapper, IGlobalService<Employee> globalServiceEmp)
        {
            _logger = logger;
            _globalServiceEmp = globalServiceEmp;
            _mapper = mapper;
        }

        [HttpGet("All")]
        // [ResponseCache(Location =ResponseCacheLocation.Any,Duration =10000)]
        public async Task<IActionResult> AllEmployee()
        {

            // var all_Emps = _globalServiceEmp.GetAllExceptName();
            // var all_Emps1 = _globalServiceEmp.GetAllExceptId();

            var all_Emps = await _globalServiceEmp.GetAll();


            if (all_Emps != null)
            {
                return Ok(all_Emps);
            }
            else
            {
                _logger.LogError("Databse Down, Faild Query process");
                return StatusCode(500, "Server Errors, Values can not Fetching");
            }
        }

        [HttpPost("Create")]
        public IActionResult CreateEmp([FromBody] EmployeeDto employeeDto)
        {

            if (employeeDto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var Email = employeeDto.Email;
            // employeeDto.Department = employeeDto.Department;

            // var Emp = _mapper.Map<Employee>(employeeDto);

            Employee employee = new()
            {
                Name = employeeDto.Name,
                Salary = employeeDto.Salary,
                Age = employeeDto.Age,
                Email = employeeDto.Email,
            };

            if (_globalServiceEmp.Create(employeeDto.Department, employee))
            {
                return StatusCode(201, employee);
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

        }

        [HttpGet]
        [Route("GetEmployee/{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            try
            {
                if (id > 0)
                {
                    var employee = _globalServiceEmp.GetById(id);
                    if (employee != null)
                        return Ok(employee);
                    return NoContent();
                }
                _logger.LogError("Employee #{id} You enterd Not Found Date", id);
                return BadRequest();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut]
        [Route("UpdateEmployee/{id}")]
        public ActionResult<Post> UpdateEmployee(int id, [FromBody] EmployeeDto employeeDto)
        {
            if (employeeDto == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var UpdateEmp = _globalServiceEmp.Upadate(id, employeeDto);
            if (UpdateEmp is Employee)
            {
                return StatusCode(200, UpdateEmp);
            }
            else
            {
                return BadRequest("Post Not Found");

            }
        }


        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult DeleteEmp([FromRoute] int id)
        {
            var result = _globalServiceEmp.DELETE(id);
            if (result)
            {
                return Ok("Employee is Deleted");
            }
            return NotFound("Faild to Delete");
        }

    }
}