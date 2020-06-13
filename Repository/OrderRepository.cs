using GDR.Context;
using GDR.Contracts;
using GDR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GDR.Repository
{
    public class OrderRepository : Repository<Order>
    {
        private readonly ContextDb _context;
        public OrderRepository(ContextDb context) : base(context)
        {
            _context = context;
        }
    }
}
