using GDR.Context;
using GDR.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GDR.Repository
{
    public class RequestRepository : Repository<Request>
    {
        protected ContextDb _context;
        public RequestRepository(ContextDb context) : base(context)
        {
            _context = context;
        }

        public override IQueryable<Request> GetAll()
        {
            return _context.Request.Include("User").AsQueryable();
        }
    }
}
