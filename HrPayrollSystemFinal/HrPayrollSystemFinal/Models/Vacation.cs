using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HrPayrollSystemFinal.Models
{
    public class Vacation
    {
        public Vacation()
        {
            Payrolls = new HashSet<Payroll>();
        }

        public int Id { get; set; }

        [Display(Name = "İşçinin A.S.A")]
        public int WorkerId { get; set; }
        public virtual Worker Worker { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Məzuniyyətin başlama tarixi")]
        [Column(TypeName = "smalldatetime")]
        public DateTime VacationStarted { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Məzuniyyətin bitmə tarixi")]
        [Column(TypeName = "smalldatetime")]
        public DateTime VacationEnded { get; set; }

        public virtual ICollection<Payroll> Payrolls { get; set; }
    }
}
