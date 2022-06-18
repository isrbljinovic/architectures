using ArtikliApi.Contracts.Repository;
using ArtikliApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ArtikliApi.Services.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ArtikliContext ArtikliContext;

        public RepositoryBase(ArtikliContext dataBaseContext)
        {
            ArtikliContext = dataBaseContext;
        }

        public void Create(T entity)
        {
            ArtikliContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            ArtikliContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges ? ArtikliContext.Set<T>()
                : ArtikliContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges ? ArtikliContext.Set<T>().Where(expression)
                : ArtikliContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            ArtikliContext.Set<T>().Update(entity);
        }
    }
}
