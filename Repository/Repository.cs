using GDR.Context;
using GDR.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GDR.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ContextDb _context;
        public Repository(ContextDb context)
        {
            _context = context;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return GetAll().Where(predicate).AsQueryable();
        }

        public virtual TEntity Find(params object[] key)
        {
            return _context.Set<TEntity>().Find(key);
        }

        public virtual void Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }

        public virtual async void SaveAll()
        {
            await _context.SaveChangesAsync();
        }

        public virtual async void Add(TEntity obj)
        {
            await _context.Set<TEntity>().AddAsync(obj);
        }

        public virtual void Delete(Func<TEntity, bool> predicate)
        {
            _context.Set<TEntity>()
                .Where(predicate).ToList()
                .ForEach(del => _context.Set<TEntity>().Remove(del));
        }
    }
}
