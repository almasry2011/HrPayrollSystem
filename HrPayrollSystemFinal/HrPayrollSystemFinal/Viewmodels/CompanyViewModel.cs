using HrPayrollSystemFinal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPayrollSystemFinal.Viewmodels
{
    public class CompanyViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa daxil edin")]
        [StringLength(200)]
        [Display(Name = "Şirkət Adı")]
        public string Name { get; set; }
    }
}
