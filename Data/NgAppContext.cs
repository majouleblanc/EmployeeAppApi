using Microsoft.EntityFrameworkCore;
using EmployeeAppApi.Extentions;
using EmployeeAppApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAppApi.Data
{
    public class NgAppContext : DbContext
    {
        public NgAppContext(DbContextOptions<NgAppContext> options) : base(options)
        {
        }

        public DbSet<Department> Departments{ get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureModels();
        }
    }
}
