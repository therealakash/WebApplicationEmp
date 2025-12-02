using Microsoft.EntityFrameworkCore;
using WebApplicationEmpProject.Models;

namespace WebApplicationEmpProject.Repositry
{
    public class Appdbcontext : DbContext
    {
        public Appdbcontext(DbContextOptions<Appdbcontext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne<Department>()
                .WithMany()
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(modelBuilder);
        }
       public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Department { get; set; }
    }
}
