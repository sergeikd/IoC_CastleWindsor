using System;
using System.Linq;
using System.Linq.Expressions;
using Oxagile.Internal.IoC.Entities;

namespace Oxagile.Internal.IoC.DALCF
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        void Add(T entity);
    }
}