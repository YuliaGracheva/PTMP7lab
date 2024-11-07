using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lab7PPTPM.Model;
using Microsoft.Extensions.Options;

namespace lab7PPTPM.Data
{
    public class lab7PPTPMContext : DbContext
    {
        public lab7PPTPMContext (DbContextOptions<lab7PPTPMContext> options)
            : base(options)
        {
        }

        public DbSet<lab7PPTPM.Model.Employee> Employee { get; set; } = default!; 
        public DbSet<lab7PPTPM.Model.PositionJob> PositionJob { get; set; } = default!;
    }
}
