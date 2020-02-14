using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPayrollSystemFinal.Models
{
    public class Shop
    {
        public Shop()
        {
            CurrentWorkPlaces = new HashSet<CurrentWorkPlace>();
            ShopPromotions = new HashSet<ShopPromotion>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa daxil edin")]
        [StringLength(200)]
        [Display(Name = "Mağaza adı")]
        public string Name { get; set; }

        [Display(Name = "Şirkət adı")]
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [Display(Name = "Departament adı")]
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public virtual ICollection<CurrentWorkPlace> CurrentWorkPlaces { get; set; }
        public virtual ICollection<ShopPromotion> ShopPromotions { get; set; }
    }
}
