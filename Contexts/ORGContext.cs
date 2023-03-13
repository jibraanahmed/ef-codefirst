using CodeFirst_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst_EF.Contexts
{
    public class ORGContext : DbContext
    {
        public ORGContext(DbContextOptions<ORGContext> options) : base(options)
        {
        }

        public DbSet<Employees> Employees { get; set; }
        public DbSet<Departments> Departments { get; set; }
    }
}
