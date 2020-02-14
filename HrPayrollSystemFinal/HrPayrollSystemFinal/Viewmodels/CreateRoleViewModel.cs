using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPayrollSystemFinal.Viewmodels
{
    public class CreateRoleViewModel
    {
        [Required(ErrorMessage = "Düzgün daxil edin")]
        [Display(Name = "Rol adı")]
        public string RoleName { get; set; }
    }
}
