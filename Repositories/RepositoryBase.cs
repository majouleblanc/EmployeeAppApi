using Microsoft.EntityFrameworkCore;
using EmployeeAppApi.Contracts;
using EmployeeAppApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EmployeeAppApi.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly NgAppContext _Context;

        public RepositoryBase(NgAppContext context)
        {
            _Context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _Context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _Context.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _Context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return _Context.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            _Context.Set<T>().Update(entity);
        }
    }
}
