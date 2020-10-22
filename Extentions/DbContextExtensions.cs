using Microsoft.EntityFrameworkCore;
using EmployeeAppApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAppApi.Extentions
{
    public static class DbContextExtensions
    {
        public static void ConfigureModels(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasOne(emp => emp.Department).WithMany(dep => dep.Employees).HasForeignKey(emp => emp.DepartmentId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.ConfigureEntities();
        }


        
        private static void ConfigureEntities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = "66774006-2371-4d5b-8518-2177bcf3f73e", Name = "HR" },
                new Department { Id= "24fd81f8-d58a-4bcc-9f35-dc6cd5641906", Name ="IT"},
                new Department { Id = "261e1685-cf26-494c-b17c-3546e65f5620", Name = "Payroll" }
                );


            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id= "a3c1880c-674c-4d18-8f91-5d3608a2c937", Name="youssef nabet",DepartmentId= "24fd81f8-d58a-4bcc-9f35-dc6cd5641906", DateOfJoining=DateTime.Now },
                new Employee { Id= "f98e4d74-0f68-4aac-89fd-047f1aaca6b6", Name="Aaron Baetens",DepartmentId= "261e1685-cf26-494c-b17c-3546e65f5620", DateOfJoining=DateTime.Now },
                new Employee { Id= "0f8fad5b-d9cb-469f-a165-70867728950e", Name="Vincent Nys",DepartmentId= "261e1685-cf26-494c-b17c-3546e65f5620", DateOfJoining = DateTime.Now }
            );
        }
    }
}
