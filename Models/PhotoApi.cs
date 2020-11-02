using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAppApi.Models
{
    public class PhotoApi
    {
        public IFormFile Photo { get; set; }
    }
}
