using lab7PPTPM.Model;
using Microsoft.EntityFrameworkCore;

namespace lab7PPTPM.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {
            Database.EnsureCreated();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<PositionJob> PositionJobs
        {
            get; set;
        }
    }
}
