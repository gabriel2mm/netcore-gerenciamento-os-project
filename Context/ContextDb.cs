using GDR.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GDR.Context
{
    public class ContextDb : IdentityDbContext
    {
        public ContextDb(DbContextOptions options) : base(options) { }

        public virtual DbSet<User> users { get; set; }
    }
}
