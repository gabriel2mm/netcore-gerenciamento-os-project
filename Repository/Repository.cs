using GDR.Context;
using GDR.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace GDR.Repository
{
    public class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        private bool isDisposed;
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

        public virtual void SaveAll()
        {
            _context.SaveChanges();
        }

        public virtual void Add(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
        }

        public virtual void Delete(Func<TEntity, bool> predicate)
        {
            _context.Set<TEntity>()
                .Where(predicate).ToList()
                .ForEach(del => _context.Set<TEntity>().Remove(del));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed) return;

            if (disposing)
            {
                _context.Dispose();
                GC.Collect();
            }

            isDisposed = true;
        }

        ~Repository()
        {
            Dispose(false);
        }
    }
}
