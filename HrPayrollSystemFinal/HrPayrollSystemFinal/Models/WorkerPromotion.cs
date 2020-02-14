using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HrPayrollSystemFinal.Models
{
    public class WorkerPromotion
    {
        public WorkerPromotion()
        {
            Payrolls = new HashSet<Payroll>();
        }

        public int Id { get; set; }

        [Display(Name ="İşçinin S.A.A")]
        public int WorkerId { get; set; }
        public virtual Worker Worker { get; set; }

        [Display(Name = "Bonus")]
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Reward { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Tarix")]
        [Column(TypeName = "smalldatetime")]
        public DateTime Date { get; set; }

        public virtual ICollection<Payroll> Payrolls { get; set; }
    }
}
