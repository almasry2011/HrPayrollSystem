using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPayrollSystemFinal.Viewmodels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "İstifadəçi adınızı daxil edin")]
        [StringLength(150)]
        [Display(Name ="Istifadəçi adı")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Adınızı daxil edin")]
        [StringLength(20)]
        [Display(Name = "Adınız")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Soyadınızı daxil edin")]
        [StringLength(20)]
        [Display(Name = "Soyadınız")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Şifrəni daxil edin")]
        [StringLength(150), DataType(DataType.Password)]
        [Display(Name = "Şifrə")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifrəni təkrarlayın")]
        [StringLength(150), DataType(DataType.Password), Compare(nameof(Password))]
        [Display(Name = "Şifrə təkrarı")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email ünvanı daxil edin")]
        [StringLength(80), EmailAddress, DataType(DataType.EmailAddress)]
        [Display(Name = "Email ünvanı")]
        public string Email { get; set; }
    }
}
