using HrPayrollSystemFinal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HrPayrollSystemFinal.Viewmodels
{
    public class ShopPromotionViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Mağaza")]
        public int ShopId { get; set; }
        public virtual Shop Shop { get; set; }

        [Required]
        [Display(Name = "Bonus")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Reward { get; set; }

        [Required]
        [Display(Name = "Maksimum məbləğ")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MaxAmount { get; set; }

        [Required]
        [Display(Name = "Minimum məbləğ")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MinAmount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Başlama tarixi")]
        [Column(TypeName = "smalldatetime")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Bitmə tarixi")]
        [Column(TypeName = "smalldatetime")]
        public DateTime FinishDate { get; set; }
    }
}
