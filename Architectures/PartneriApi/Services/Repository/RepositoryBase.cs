using Microsoft.EntityFrameworkCore;
using PartneriApi.Contracts.Repository;
using PartneriApi.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace PartneriApi.Services.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected PartneriContext PartneriContext;

        public RepositoryBase(PartneriContext dataBaseContext)
        {
            PartneriContext = dataBaseContext;
        }

        public void Create(T entity)
        {
            PartneriContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            PartneriContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges ? PartneriContext.Set<T>()
                : PartneriContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges ? PartneriContext.Set<T>().Where(expression)
                : PartneriContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            PartneriContext.Set<T>().Update(entity);
        }
    }
}
