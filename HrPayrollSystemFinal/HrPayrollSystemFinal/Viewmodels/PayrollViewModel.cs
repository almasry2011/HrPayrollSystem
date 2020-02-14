using HrPayrollSystemFinal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HrPayrollSystemFinal.Viewmodels
{
    public class PayrollViewModel
    {
        public int Id { get; set; }

        public int WorkerId { get; set; }
        public virtual Worker Worker { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        
        public int CountofAbsentDays { get; set; }

        public decimal Bonus { get; set; }
        
        public int ShopPromotionId { get; set; }
        public ShopPromotion ShopPromotion { get; set; }

        public decimal ShopBonus { get; set; }

        public int WorkerPromotionId { get; set; }
        public WorkerPromotion WorkerPromotion { get; set; }

        public decimal VacationBonus { get; set; }

        public int VacationId { get; set; }
        public Vacation Vacation { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalSalary { get; set; }

        public static implicit operator PayrollViewModel(Payroll v)
        {
            throw new NotImplementedException();
        }
    }
}
