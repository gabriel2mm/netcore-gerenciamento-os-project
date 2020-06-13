using GDR.Context;
using GDR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GDR.Repository
{
    public class RequestRepository : Repository<Request>
    {
        private readonly ContextDb _context;
        public RequestRepository(ContextDb context) : base(context)
        {
            _context = context;
        }
    }
}
