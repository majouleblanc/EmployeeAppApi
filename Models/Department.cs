using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAppApi.Models
{
    public class Department
    {
        [Key]
        public string Id { get; set; }
        [Required, StringLength(maximumLength:25, MinimumLength =2, ErrorMessage ="Department name length must be between 2 and 25 characters!")]
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; private set; }
    }
}
