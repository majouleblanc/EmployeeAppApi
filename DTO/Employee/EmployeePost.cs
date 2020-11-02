using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAppApi.DTO.Employee
{
    public class EmployeePost
    {
        
        [Required, MaxLength(80, ErrorMessage = "Employee name must be less than 80 characters"), MinLength(3, ErrorMessage = "Employee name must be greater than 3 characters!")]
        public string Name { get; set; }

        [Required]
        public DateTime DateOfJoining { get; set; }

        public string DepartmentName { get; set; }
    }
}
