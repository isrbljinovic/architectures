using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NLayered.Contracts.Repository;
using NLayered.DataLayer.DbContexts;

namespace NLayered.DataLayer
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected FirmaContext FirmaContext;

        public RepositoryBase(FirmaContext dataBaseContext)
        {
            FirmaContext = dataBaseContext;
        }

        public void Create(T entity)
        {
            FirmaContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            FirmaContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges ? FirmaContext.Set<T>()
                : FirmaContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges ? FirmaContext.Set<T>().Where(expression)
                : FirmaContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            FirmaContext.Set<T>().Update(entity);
        }
    }
}
