using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAppApi.Contracts;
using EmployeeAppApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly ILogger<DepartmentController> _Logger;

        public DepartmentController(IUnitOfWork unitOfWork, ILogger<DepartmentController> logger)
        {
            _UnitOfWork = unitOfWork;
            _Logger = logger;
        }

        // GET: api/Department
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var departmentsWithEmployees = await _UnitOfWork.DepartmentRepository.GetAllDepartmentsWithEmployeesAsync();
            return Ok(departmentsWithEmployees);
        }

        // GET api/Department/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var departmentWithEmployee = await _UnitOfWork.DepartmentRepository.GetDepartmentWithEmployeesByIdAsync(id);
            if (departmentWithEmployee == null)
            {
                return NotFound($"Department with Id : {id} doent exist");
            }
            return Ok(departmentWithEmployee);
        }

        // POST api/Department
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Department department)
        {
            _UnitOfWork.DepartmentRepository.CreateDepartment(department);
            await _UnitOfWork.SaveChangesAsync();
            return Ok(department);
        }

        // PUT api/Department/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromForm] Department department)
        {
            if (id !=department.Id)
            {
                return BadRequest("Id and department id do not match!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _UnitOfWork.DepartmentRepository.UpdateDepartment(department);
            await _UnitOfWork.SaveChangesAsync();
            return Ok(department);
        }

        // DELETE api/<Department/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var department = await _UnitOfWork.DepartmentRepository.GetDepartmentWithEmployeesByIdAsync(id);
            if (department == null)
            {
                return BadRequest($"Department with Id : {id} doesn't exist!");
            }
            _UnitOfWork.DepartmentRepository.DeleteDepartment(department);
            await _UnitOfWork.SaveChangesAsync();

            return Ok($"Department with Id : {id} was successfully deleted!");
        }
    }
}
