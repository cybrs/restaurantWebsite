using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Restaurant.Data;
using Restaurant.Contracts;

namespace Restaurant.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext RepositoryContext { get; set; }

        public RepositoryBase(ApplicationDbContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public RepositoryBase()
        {
        }

        public IEnumerable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression);
        }

        public void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }

        public void Save()
        {
            this.RepositoryContext.SaveChanges();
        }
    
    }
}
