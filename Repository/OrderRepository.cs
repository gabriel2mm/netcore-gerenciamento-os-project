using GDR.Context;
using GDR.Contracts;
using GDR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GDR.Repository
{
    public class OrderRepository : Repository<Order>
    {
        private readonly ContextDb _context;
        public OrderRepository(ContextDb context) : base(context)
        {
            _context = context;
        }

        public override void Update(Order obj)
        {
            _context.Entry(obj.User).State = EntityState.Modified;
            _context.Entry(obj.Request).State = EntityState.Modified;
            _context.Entry(obj).State = EntityState.Modified;
        }
        public override void Add(Order obj)
        {
            _context.Set<User>().Attach(obj.User).State = EntityState.Unchanged;
            _context.Set<Order>().Add(obj);
            _context.ChangeTracker.DetectChanges();
        }

        public override IQueryable<Order> GetAll()
        {
            return _context.Order.Include("User").AsQueryable();
        }

        public override Order Find(params object[] key)
        {
            Order order = _context.Order.Find(key);
            _context.Entry(order).Reference(p => p.User).Load();
            _context.Entry(order).Reference(p => p.Request).Load();

            return order;
        }
    }
}
