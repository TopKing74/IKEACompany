using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MVC04.DAL.Models.Auth;
using MVC04.DAL.Models.Department;
using MVC04.DAL.Models.Employee;


namespace MVC04.DAL.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet <Employee> Employees { get; set; }

        }
}
