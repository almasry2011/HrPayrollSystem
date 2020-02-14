using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HrPayrollSystemFinal.Models
{
    public class PreviousWorkPlace
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Zəhmət olmasa daxil edin")]
        [Display(Name = "A.S.A")]
        public int WorkerId { get; set; }
        public virtual Worker Worker { get; set; }

        [Required(ErrorMessage = "Zəhmət olmasa daxil edin")]
        [Display(Name = "İş yerinin adı")]
        public string WorkPlaceName { get; set; }

        [Required(ErrorMessage = "Zəhmət olmasa daxil edin")]
        [DataType(DataType.Date)]
        [Display(Name = "Daxil olma tarixi")]
        [Column(TypeName = "smalldatetime")]
        public DateTime EntryDate { get; set; }

        [Required(ErrorMessage = "Zəhmət olmasa daxil edin")]
        [Display(Name = "Çıxış tarixi")]
        [DataType(DataType.Date)]
        [Column(TypeName = "smalldatetime")]
        public DateTime ExitDate { get; set; }

        [Required(ErrorMessage = "Zəhmət olmasa daxil edin")]
        [Display(Name = "İşdən çıxma səbəbi")]
        public string ReasonOfTermination { get; set; }
    }
}
