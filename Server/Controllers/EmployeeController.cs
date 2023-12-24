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
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        public EmployeeController(ILogger<EmployeeController> logger, IMapper mapper, IDepartmentService departmentService, IGlobalService<Employee> globalServiceEmp)
        {
            _logger = logger;
            _globalServiceEmp = globalServiceEmp;
            _departmentService = departmentService;
            _mapper = mapper;
        }

        [HttpGet("All")]
        public IActionResult AllEmployee()
        {

            var all_Emps = _globalServiceEmp.GetAll();

            if (all_Emps != null)
            {
                return Ok(all_Emps);
            }
            else
            {
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

    }
}