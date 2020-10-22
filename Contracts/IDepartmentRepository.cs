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
        Task<Department> GetDepartmentByIdAsync(string departmentId);
        Task<Department> GetDepartmentWithEmployeesAsync(string departmentId);
        Task<Department> CreateDepartmentAsync(Department department);
        Department UpdateDepartment(Department department);
        Department DeleteDepartment(Department department);
    }
}
