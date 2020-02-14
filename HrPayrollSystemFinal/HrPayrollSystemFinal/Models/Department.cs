using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPayrollSystemFinal.Models
{
    public class Department
    {
        public Department()
        {
            Shops = new HashSet<Shop>();
            Positions = new HashSet<Position>();
            CurrentWorkPlaces = new HashSet<CurrentWorkPlace>();
            Payrolls = new HashSet<Payroll>();
        }

        public int Id { get; set; }
        [Required]
        [Display(Name = "Departament adı")]
        public string Name { get; set; }

        [Display(Name = "Şirkət adı")]
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public virtual ICollection<Shop> Shops { get; set; }
        public virtual ICollection<Position> Positions { get; set; }
        public virtual ICollection<CurrentWorkPlace> CurrentWorkPlaces { get; set; }
        public virtual ICollection<Payroll> Payrolls { get; set; }
    }
}
