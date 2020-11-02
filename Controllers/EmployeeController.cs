using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAppApi.Contracts;
using EmployeeAppApi.DTO.Employee;
using EmployeeAppApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EmployeeAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly ILogger<DepartmentController> _Logger;
        private readonly IWebHostEnvironment _Environment;
        private readonly IConfiguration _Configuration;

        public EmployeeController(IUnitOfWork unitOfWork, ILogger<DepartmentController> logger, IWebHostEnvironment environment, IConfiguration configuration)
        {
            _UnitOfWork = unitOfWork;
            _Logger = logger;
            _Environment = environment;
            _Configuration = configuration;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employeesWithdepartments = await _UnitOfWork.EmployeeRepository.GetAllEmployeesWithDepartmentssAsync();

            if (employeesWithdepartments != null)
            {
                foreach (var emp in employeesWithdepartments)
                {
                    if (emp.PhotoFileName != null)
                    {
                        emp.PhotoFileName = _Configuration.GetSection("AppImagesUrl").Value + emp.PhotoFileName;
                    }
                }
            }

            return Ok(employeesWithdepartments);
        }

        // GET api/Employee/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var employeeWithDepartments = await _UnitOfWork.EmployeeRepository.GetEmployeeWithDepartmentsByIdAsync(id);
            if (employeeWithDepartments == null)
            {
                return NotFound(new { message = $"Employee with Id : {id} doesn't exist" });
            }

            employeeWithDepartments.PhotoFileName = _Configuration.GetSection("AppImagesUrl").Value + employeeWithDepartments.PhotoFileName;

            return Ok(employeeWithDepartments);
        }

        // POST api/Employee
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] EmployeePost employeeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = new Employee
            {
                Name = employeeDTO.Name,
                DateOfJoining = employeeDTO.DateOfJoining,
            };

            var employeeDepartment = (await _UnitOfWork.DepartmentRepository.GetAllDepartmentsAsync()).Where(dep => dep.Name == employeeDTO.DepartmentName).FirstOrDefault();

            if (employeeDepartment != null)
            {
                employee.DepartmentId = employeeDepartment.Id;
                //employee.Department = employeeDepartment;
            }

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

            return Ok(new { message = $"Employee with Id : {id} was successfully deleted!" });
        }

        [HttpPost("{id}/SavePhoto")]
        public async Task<IActionResult> SaveEmployeePhoto(string id, [FromForm] PhotoApi file)
        {
            var employee = await _UnitOfWork.EmployeeRepository.GetEmployeeWithDepartmentsByIdAsync(id);

            if (employee == null)
            {
                return BadRequest(new { message = "employee not found" });
            }

            if (file.Photo == null)
            {
                return BadRequest(new { message = "photo must not be null" });
            }

            //employee already have a foto
            if (employee.PhotoFileName != null)
            {
                var existingFotoFile = Path.Combine(_Environment.WebRootPath, "images", employee.PhotoFileName);
                if (System.IO.File.Exists(existingFotoFile))
                {
                    System.IO.File.Delete(existingFotoFile);
                }
            }

            var fileName = Guid.NewGuid() + "_" + file.Photo.FileName;

            var filePath = Path.Combine(_Environment.WebRootPath, "images", fileName);

            using var stream = System.IO.File.Create(filePath);
            await file.Photo.CopyToAsync(stream);
            employee.PhotoFileName = fileName;

            _UnitOfWork.EmployeeRepository.UpdateEmployee(employee);

            await _UnitOfWork.SaveChangesAsync();

            return Ok(employee);
        }
    }


}
