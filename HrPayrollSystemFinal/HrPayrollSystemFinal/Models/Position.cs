using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HrPayrollSystemFinal.Models
{
    public class Position
    {
        public Position()
        {
            CurrentWorkPlaces = new HashSet<CurrentWorkPlace>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Zəhmət olmasa daxil edin")]
        [StringLength(200)]
        [Display(Name = "Vəzifə adı")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Zəhmət olmasa daxil edin")]
        [Display(Name = "Maaş")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }

        [Display(Name = "Şirkət")]
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [Display(Name = "Departament")]
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public virtual ICollection<CurrentWorkPlace> CurrentWorkPlaces { get; set; }
        public virtual ICollection<Payroll> Payrolls { get; set; }
    }
}
