using EmployeeAppApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAppApi.Contracts
{
    public interface IDepartmentRepository : IRepositoryBase<Department>
    {
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();

        Task<IEnumerable<Department>> GetAllDepartmentsWithEmployeesAsync();

        Task<Department> GetDepartmentWithEmployeesByIdAsync(string departmentId);
        
        Task<Department> GetDepartmentWithEmployeesAsync(string departmentId);

        Department CreateDepartment(Department department);

        Department UpdateDepartment(Department department);

        Department DeleteDepartment(Department department);
    }
}
