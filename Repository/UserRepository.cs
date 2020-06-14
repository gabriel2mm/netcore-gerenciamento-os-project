
using GDR.Context;
using GDR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GDR.Repository
{
    public class UserRepository : Repository<User>
    {
        private readonly ContextDb _context;
        public UserRepository(ContextDb context) : base(context)
        {
            _context = context;
        }  
    }
}
