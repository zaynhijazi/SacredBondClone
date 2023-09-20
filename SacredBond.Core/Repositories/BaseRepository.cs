using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SacredBond.Core.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SacredBond.Core.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext DataContext { get; set; }
        public BaseRepository(ApplicationDbContext dataContext)
        {
            DataContext = dataContext;
        }

        public IQueryable<T> GetAll()
        {
            return DataContext.Set<T>();
        }

        public T? Get(int Id)
        {
            return DataContext.Find<T>(Id);
        }

        public async Task<T?> GetAsync(int Id)
        {
            return await DataContext.FindAsync<T>(Id);
        }

        public T? Get(Guid Id)
        {
            return DataContext.Find<T>(Id);
        }

        public async Task<T?> GetAsync(Guid Id)
        {
            return await DataContext.FindAsync<T>(Id);
        }

        public void Add(T entity)
        {
            DataContext.Set<T>().Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            //var addedEntity = DataContext.Entry(entity);
            //addedEntity.State = EntityState.Added;
          
            await DataContext.Set<T>().AddAsync(entity);
            await DataContext.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            DataContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await DataContext.SaveChangesAsync();
        }

        public IQueryable<T> GetAsQueryable(Expression<Func<T, bool>> where)
        {
            return DataContext.Set<T>().Where(where).AsQueryable();
        }

        public async Task DeleteAsync(object Id)
        {
            T? existing = await DataContext.FindAsync<T>(Id);
            if (existing != null)
            {
                DataContext.Set<T>().Remove(existing);
            }
        }

        public void DeleteMany(Expression<Func<T, bool>> where)
        {
            var entities = GetAsQueryable(where);
            DataContext.Set<T>().RemoveRange(entities);
        }
    }

    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T? Get(int Id);
        Task<T?> GetAsync(int Id);
        T? Get(Guid Id);
        Task<T?> GetAsync(Guid Id);
        void Add(T entity);
        Task AddAsync(T entity);
        void SaveChanges();
        Task SaveChangesAsync();
        IQueryable<T> GetAsQueryable(Expression<Func<T, bool>> where);
        Task DeleteAsync(object Id);
        void DeleteMany(Expression<Func<T, bool>> where);
    }
}
