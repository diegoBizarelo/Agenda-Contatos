﻿using Microsoft.EntityFrameworkCore;
using SGA.ApplicationCore.Interfaces.Repository;
using SGA.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SGA.Infrastructure.Repository
{
    public class EFRepository<T> : IRepository<T> where T : class
    {

        protected readonly BaseContext _dbContext;
        public EFRepository(BaseContext context)
        {
            _dbContext = context;
        }
        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public virtual IEnumerable<T> Search(Expression<Func<T, bool>> predicate)
        {
            var result = _dbContext.Set<T>().Where(predicate);
            return result.AsEnumerable();
        }

        public T UpDate(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return entity;
        }
    }
}
