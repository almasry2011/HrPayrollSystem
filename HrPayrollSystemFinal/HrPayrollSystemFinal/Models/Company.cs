using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPayrollSystemFinal.Models
{
    public class Company
    {
        public Company()
        {
            Shops = new HashSet<Shop>();
            Departments = new HashSet<Department>();
            Positions = new HashSet<Position>();
            Payrolls = new HashSet<Payroll>();
            CurrentWorkPlaces = new HashSet<CurrentWorkPlace>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa daxil edin")]
        [StringLength(200)]
        [Display(Name = "Şirkət Adı")]
        public string Name { get; set; }

        public virtual ICollection<Shop> Shops { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Position> Positions { get; set; }
        public virtual ICollection<Payroll> Payrolls { get; set; }
        public virtual ICollection<CurrentWorkPlace> CurrentWorkPlaces { get; set; }
    }
}
