using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPayrollSystemFinal.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required(ErrorMessage = "Adınızı daxil edin")]
        [StringLength(50, ErrorMessage = "Maksimum uzunluq 50 simvol ola bilər")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyadınızı daxil edin")]
        [StringLength(50, ErrorMessage = "Maksimum uzunluq 50 simvol ola bilər")]
        public string LastName { get; set; }
    }
}
