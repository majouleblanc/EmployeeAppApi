using EmployeeAppApi.Contracts;
using EmployeeAppApi.Data;
using EmployeeAppApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAppApi.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeAppContext context) : base(context)
        {

        }

        public Employee CreateEmployee(Employee employee)
        {
            Create(employee);
            return employee;
        }

        public Employee DeleteEmployee(Employee employee)
        {
            Delete(employee);
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await GetAll().OrderBy(emp => emp.Name).ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesWithDepartmentssAsync()
        {
            return await GetAll().Include(emp => emp.Department).OrderBy(emp => emp.Name).ToListAsync();
        }

        public async Task<Employee> GetEmployeeWithDepartmentsByIdAsync(string employeeId)
        {
            return await GetByCondition(emp=>emp.Id == employeeId).FirstOrDefaultAsync();
        }

        public Employee UpdateEmployee(Employee employee)
        {
            Update(employee);
            return employee;
        }
    }
}
