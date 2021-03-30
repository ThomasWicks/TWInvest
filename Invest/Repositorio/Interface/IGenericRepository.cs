using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Invest.Repositorio
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllNoTracking();
        T GetById(int id);
        T GetByIdNoTracking(int id);
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        void Insert(T obj);
        void InsertFromJob(T obj);
        void Update(T obj);
        void Delete(int id);
        void Save();
    }
}