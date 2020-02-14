using HrPayrollSystemFinal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HrPayrollSystemFinal.Viewmodels
{
    public class CurrentWPViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Zəhmət olmasa daxil edin")]
        [Display(Name = "A.S.A")]
        public int WorkerId { get; set; }
        public virtual Worker Worker { get; set; }

        [Required(ErrorMessage = "Zəhmət olmasa daxil edin")]
        [Display(Name = "Şirkət")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [Required(ErrorMessage = "Zəhmət olmasa daxil edin")]
        [Display(Name = "Departament")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        [Required(ErrorMessage = "Zəhmət olmasa daxil edin")]
        [Display(Name = "Mağaza")]
        public int ShopId { get; set; }
        public virtual Shop Shop { get; set; }

        [Required(ErrorMessage = "Zəhmət olmasa daxil edin")]
        [Display(Name = "Vəzifə")]
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Daxil olma tarixi")]
        [Column(TypeName = "smalldatetime")]
        public DateTime EntryDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Çıxış tarixi")]
        [Column(TypeName = "smalldatetime")]
        public DateTime? ExitDate { get; set; }
    }
}
