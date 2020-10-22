using Microsoft.EntityFrameworkCore;
using EmployeeAppApi.Contracts;
using EmployeeAppApi.Data;
using EmployeeAppApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAppApi.Repositories
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(NgAppContext context): base(context)
        {

        }

        public async Task<Department> CreateDepartmentAsync(Department department)
        {
            await CreateAsync(department);
            return department;
        }

        public Department DeleteDepartment(Department department)
        {
            Delete(department);
            return department;
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<Department> GetDepartmentByIdAsync(string departmentId)
        {
            return await GetByCondition(dep => dep.Id.Equals(departmentId)).FirstOrDefaultAsync();            
        }

        public async Task<Department> GetDepartmentWithEmployeesAsync(string departmentId)
        {
            return await GetByCondition(dep => dep.Id.Equals(departmentId)).Include(dep=>dep.Employees).FirstOrDefaultAsync();
        }

        public Department UpdateDepartment(Department department)
        {
            Update(department);
            return department;
        }
    }
}
