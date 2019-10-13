using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Technology_Tp1_React.General
{
    public interface IRepository<T> 
        where T : IEntity
    {
        IQueryable<T> GetAll();

        T GetById(int id);

        void Create(T document);

        void Update(T document);

        T Where(Expression<Func<T, bool>> predicate);

        IEnumerable<T> Filter(Expression<Func<T, bool>> predicate);

        void Delete(int id);

        void SaveChanges();
    }
}
