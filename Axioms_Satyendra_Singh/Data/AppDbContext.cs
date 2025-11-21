using Microsoft.EntityFrameworkCore;
using Axioms_Satyendra_Singh.Models;

namespace Axioms_Satyendra_Singh.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User_Login> User_Logins { get; set; }
        public DbSet<Employee> Employee { get; set; } = default!;
        public DbSet<Customer> Customer { get; set; } = default!;
        public DbSet<Report> Report { get; set; } = default!;

    }
}
