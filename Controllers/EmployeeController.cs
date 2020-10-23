using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAppApi.Contracts;
using EmployeeAppApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly ILogger<DepartmentController> _Logger;

        public EmployeeController(IUnitOfWork unitOfWork, ILogger<DepartmentController> logger)
        {
            _UnitOfWork = unitOfWork;
            _Logger = logger;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employeesWithdepartments = await _UnitOfWork.EmployeeRepository.GetAllEmployeesWithDepartmentssAsync();
            return Ok(employeesWithdepartments);
        }

        // GET api/Employee/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var employeeWithDepartments = await _UnitOfWork.EmployeeRepository.GetEmployeeWithDepartmentsByIdAsync(id);
            if ( employeeWithDepartments== null)
            {
                return NotFound($"Employee with Id : {id} doesn't exist");
            }
            return Ok(employeeWithDepartments);
        }

        // POST api/Employee
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Employee employee)
        {
            _UnitOfWork.EmployeeRepository.CreateEmployee(employee);
            await _UnitOfWork.SaveChangesAsync();
            return Ok(employee);
        }

        // PUT api/Employee/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromForm] Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest("Id and Employee id do not match!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _UnitOfWork.EmployeeRepository.UpdateEmployee(employee);
            await _UnitOfWork.SaveChangesAsync();
            return Ok(employee);
        }

        // DELETE api/<Employee/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var employee = await _UnitOfWork.EmployeeRepository.GetEmployeeWithDepartmentsByIdAsync(id);
            if (employee == null)
            {
                return BadRequest($"Department with Id : {id} doesn't exist!");
            }
            _UnitOfWork.EmployeeRepository.DeleteEmployee(employee);
            await _UnitOfWork.SaveChangesAsync();

            return Ok($"Employee with Id : {id} was successfully deleted!");
        }
    }


}
