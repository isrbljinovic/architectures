using System;
using System.Linq;
using System.Linq.Expressions;
using DokumentiApi.Contracts.Repository;
using DokumentiApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DokumentiApi.Services.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DokumentiContext DokumentiContext;

        public RepositoryBase(DokumentiContext dataBaseContext)
        {
            DokumentiContext = dataBaseContext;
        }

        public void Create(T entity)
        {
            DokumentiContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            DokumentiContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges ? DokumentiContext.Set<T>()
                : DokumentiContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges ? DokumentiContext.Set<T>().Where(expression)
                : DokumentiContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            DokumentiContext.Set<T>().Update(entity);
        }
    }
}
