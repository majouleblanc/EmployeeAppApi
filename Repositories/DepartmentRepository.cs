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
        public DepartmentRepository(EmployeeAppContext context): base(context)
        {

        }

        public Department CreateDepartment(Department department)
        {
            Create(department);
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

        public async Task<IEnumerable<Department>> GetAllDepartmentsWithEmployeesAsync()
        {
            return await GetAll().Include(dep => dep.Employees).ToListAsync();
        }

        public async Task<Department> GetDepartmentWithEmployeesByIdAsync(string departmentId)
        {
            return await GetByCondition(dep => dep.Id.Equals(departmentId)).FirstOrDefaultAsync();            
        }

        public Department UpdateDepartment(Department department)
        {
            Update(department);
            return department;
        }
    }
}
