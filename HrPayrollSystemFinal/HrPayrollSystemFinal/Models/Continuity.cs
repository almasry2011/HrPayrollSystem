using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using HrPayrollSystemFinal.Models;
using HrPayrollSystemFinal.Models.Enums;

namespace HrPayrollSystemFinal.Models
{
    public class Continuity
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "İşçinin S.A.A")]
        public int WorkerId { get; set; }
        public virtual Worker Worker { get; set; }

        [Required(ErrorMessage = "Tarixi daxil edin")]
        [Display(Name = "Tarix")]
        [DataType(DataType.Date)]
        [Column(TypeName = "smalldatetime")]
        public DateTime Date { get; set; }

        [Display(Name = "Davamiyyət")]
        public Status Status { get; set; }

        [Display(Name = "Səbəb")]
        [StringLength(maximumLength: 100, MinimumLength = 5, ErrorMessage = "Zəhmət olmasa düzgün daxil edin!")]
        public string ReasonName { get; set; }

        [Display(Name = "Qeyd")]
        public Absent Reason { get; set; }
    }
}
