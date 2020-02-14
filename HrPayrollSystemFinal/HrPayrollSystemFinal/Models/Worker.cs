using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HrPayrollSystemFinal.Models
{
    public class Worker
    {
        public Worker()
        {
            CurrentWorkPlaces = new HashSet<CurrentWorkPlace>();
            PreviousWorkPlaces = new HashSet<PreviousWorkPlace>();
            Vacations = new HashSet<Vacation>();
            Continuities = new HashSet<Continuity>();
            WorkerPromotions = new HashSet<WorkerPromotion>();
            Payrolls = new HashSet<Payroll>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Zəhmət olmasa daxil edin")]
        [Display(Name = "Ad")]
        [StringLength(maximumLength: 100, ErrorMessage = "Adınızı düzgün daxil edin!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Zəhmət olmasa daxil edin")]
        [Display(Name = "Soyad")]
        [StringLength(maximumLength: 100, ErrorMessage = "Soyadınızı düzgün daxil edin!")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Zəhmət olmasa daxil edin")]
        [Display(Name = "Ata adı")]
        [StringLength(maximumLength: 100, ErrorMessage = "Ata adınızı düzgün daxil edin!")]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "Zəhmət olmasa daxil edin")]
        [DataType(DataType.Date)]
        [Display(Name = "Doğum tarixi")]
        [Column(TypeName = "smalldatetime")]
        public DateTime BirthdayDate { get; set; }

        [Required(ErrorMessage = "Zəhmət olmasa daxil edin")]
        [Display(Name = "Yaşayış ünvanı")]
        [StringLength(maximumLength: 300, ErrorMessage = "Faktiki adresinizi düzgün daxil edin!")]
        public string CurrentAdress { get; set; }

        [Required(ErrorMessage = "Zəhmət olmasa daxil edin")]
        [Display(Name = "Qeydiyyat olduğu rayon")]
        [StringLength(maximumLength: 300, ErrorMessage = "Rayon qeydiyyatınızı düzgün daxil edin!")]
        public string DistrictRegistration { get; set; }

        [Required(ErrorMessage = "Zəhmət olmasa daxil edin")]
        [Display(Name = "Email ünvanı")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email düzgün deyil")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Zəhmət olmasa daxil edin")]
        [Display(Name = "Passport nömrəsi")]
        [StringLength(maximumLength: 300, ErrorMessage = "Passport nömrənizi düzgün daxil edin!") ]
        public string PassportNumber { get; set; }

        [Required(ErrorMessage = "Zəhmət olmasa daxil edin")]
        [DataType(DataType.Date)]
        [Display(Name = "Passportun son istifadə tarixi")]
        [Column(TypeName = "smalldatetime")]
        public DateTime PassportExpirationDate { get; set; }

        [Required(ErrorMessage = "Zəhmət olmasa daxil edin")]
        [Display(Name = "Təhsil")]
        [EnumDataType(typeof(Education))]
        public Education EducationType { get; set; }

        [Required(ErrorMessage = "Zəhmət olmasa daxil edin")]
        [Display(Name = "Ailə vəziyyəti")]
        [EnumDataType(typeof(MartialStatus))]
        public MartialStatus MartialStatus { get; set; }

        [Required(ErrorMessage = "Zəhmət olmasa daxil edin")]
        [Display(Name = "Cinsi")]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        public string PhotoPath { get; set; }

        public virtual ICollection<CurrentWorkPlace> CurrentWorkPlaces { get; set; }
        public virtual ICollection<PreviousWorkPlace> PreviousWorkPlaces { get; set; }
        public virtual ICollection<Vacation> Vacations { get; set; }
        public virtual ICollection<Continuity> Continuities { get; set; }
        public virtual ICollection<WorkerPromotion> WorkerPromotions { get; set; }
        public virtual ICollection<Payroll> Payrolls { get; set; }
    }
}
