﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EmployeeAppApi.Contracts
{
    public interface IRepositoryBase<T>
    {
         IQueryable<T> GetAll();
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
