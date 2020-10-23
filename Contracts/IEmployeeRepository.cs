using EmployeeAppApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAppApi.Contracts
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();

        Task<IEnumerable<Employee>> GetAllEmployeesWithDepartmentssAsync();

        Task<Employee> GetEmployeeWithDepartmentsByIdAsync(string employeeId);

        Employee CreateEmployee(Employee employee);

        Employee UpdateEmployee(Employee employee);

        Employee DeleteEmployee(Employee employee);
    }
}
