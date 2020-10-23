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
        private IDepartmentRepository _DepartmentRepository;
        private IEmployeeRepository _EmployeeRepository;


        private readonly EmployeeAppContext _Context;
        public UnitOfWork(EmployeeAppContext context)
        {
            _Context = context;
        }


        public IDepartmentRepository DepartmentRepository
        {
            get
            {
                if (_DepartmentRepository == null)
                {
                    _DepartmentRepository =  new DepartmentRepository(_Context);
                }
                return _DepartmentRepository;
            }

        }

        public IEmployeeRepository EmployeeRepository { 
            get {
                if (_EmployeeRepository == null)
                {
                    _EmployeeRepository = new EmployeeRepository(_Context);
                }
                return _EmployeeRepository;
            } 
        }

        public async Task SaveChangesAsync()
        {
            await _Context.SaveChangesAsync();
        }
    }
}
