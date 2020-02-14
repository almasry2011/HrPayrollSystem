using HrPayrollSystemFinal.Viewmodels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HrPayrollSystemFinal.Models
{
    public class Payroll
    {
        public int Id { get; set; }

        public int WorkerId { get; set; }
        public virtual Worker Worker { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }

        public int CountofAbsentDays { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Bonus { get; set; }

        public int? ShopPromotionId { get; set; }
        public ShopPromotion ShopPromotion { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ShopBonus { get; set; }

        public int? WorkerPromotionId { get; set; }
        public WorkerPromotion WorkerPromotion { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal VacationBonus { get; set; }

        public int? VacationId { get; set; }
        public Vacation Vacation { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalSalary { get; set; }

        [Display(Name = "Maaşın ödənilmə tarixi")]
        [DataType(DataType.Date)]
        public DateTime DateOfPaidSalaries { get; set; }
    }
}
