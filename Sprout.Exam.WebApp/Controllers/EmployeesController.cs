using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Common.Enums;
using Sprout.Exam.Business.Contracts;

namespace Sprout.Exam.WebApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        /// <summary>
        /// Get all employee.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = (await _employeeService.GetAllAsync());
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }


        /// <summary>
        /// Get Employee by Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = (await _employeeService.GetByIdAsync(id));
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception )
            {
                return StatusCode(500);
            }

        }


        /// <summary>
        /// Update Employee
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(EditEmployeeDto input)
        {
            try
            {
                await _employeeService.EditAsync(input);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            
        }


        /// <summary>
        /// Create an employee
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CreateEmployeeDto input)
        {
            try
            {
                var id = (await _employeeService.CreateAsync(input)).Id;
                return Created($"/api/employees/{id}", id);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }


        /// <summary>
        /// Tag employee as deleted
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _employeeService.DeleteAsync(id);
                return Ok(id);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }


        /// <summary>
        /// Get Computation based on the employee type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="absentDays"></param>
        /// <param name="workedDays"></param>
        /// <returns></returns>
        [HttpPost("{id}/calculate")]
        public async Task<IActionResult> Calculate(ComputeEmployeeDto dto)
        {
            try
            {
                var salary = await _employeeService.ComputeAsync(dto.Id, dto.AbsentDays, dto.WorkedDays);
                return Ok(salary);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
