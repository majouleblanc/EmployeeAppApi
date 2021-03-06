﻿using Microsoft.EntityFrameworkCore;
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
        private readonly EmployeeAppContext _Context;

        public RepositoryBase(EmployeeAppContext context)
        {
            _Context = context;
        }

        public void Create(T entity)
        {
            _Context.Set<T>().Add(entity);
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
