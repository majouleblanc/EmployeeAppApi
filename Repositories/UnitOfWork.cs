using EmployeeAppApi.Contracts;
using EmployeeAppApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAppApi.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NgAppContext _Context;

        public UnitOfWork(NgAppContext context)
        {
            _Context = context;
        }

        private IDepartmentRepository _DepartmentRepository;

        public IDepartmentRepository DepartmentRepository
        {
            get
            {
                if (_DepartmentRepository == null)
                {
                    return new DepartmentRepository(_Context);
                }
                return DepartmentRepository;
            }
        }

        public async Task SaveChanges()
        {
            await _Context.SaveChangesAsync();
        }
    }
}
