using HrPayrollSystemFinal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPayrollSystemFinal.Viewmodels
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa daxil edin")]
        [Display(Name = "Departament adı")]
        public string Name { get; set; }

        [Display(Name = "Şirkət adı")]
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
