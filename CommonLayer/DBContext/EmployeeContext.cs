using CommonLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace CommonLayer.DBContext
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options): base(options)
        {

        }

        public DbSet<EmployeeData> EmployeeDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EmployeeData>()
                .HasKey(p => p.EmployeeId)
                .HasName("PrimaryKey_EmployeeId");

            builder.Entity<EmployeeData>()
                .HasIndex(unique => unique.Email)
                .IsUnique();

            builder.Entity<EmployeeData>()
                .HasIndex(unique => unique.Contact)
                .IsUnique();
        }
    }
}
