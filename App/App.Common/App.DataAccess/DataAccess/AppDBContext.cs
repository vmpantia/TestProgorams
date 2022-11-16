using App.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Common.DataAccess
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() : base() { }
        public AppDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Department_TRN> Department_TRNs { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Position_TRN> Position_TRNs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Employee_TRN> Employee_TRNs { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Constants.CON_STRING);
            }
        }
    }
}
