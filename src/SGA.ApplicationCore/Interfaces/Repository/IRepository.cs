using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SGA.ApplicationCore.Interfaces.Repository
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        T UpDate(T entity);
        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> Search(Expression<Func<T, bool>> predicate);
        void Remove(T entity);
    }
}
