using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPayrollSystemFinal.Viewmodels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email ünvanı daxil edin")]
        [StringLength(80), EmailAddress, DataType(DataType.EmailAddress)]
        [Display(Name = "Email ünvanı")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifrəni daxil edin")]
        [StringLength(150), DataType(DataType.Password)]
        [Display(Name = "Şifrə")]
        public string Password { get; set; }

        [Display(Name = "Yadda saxla")]
        public bool RememberMe { get; set; }
    }
}
