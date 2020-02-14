using HrPayrollSystemFinal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HrPayrollSystemFinal.Viewmodels;
namespace HrPayrollSystemFinal.DAL
{
    public class HrPrSystemDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Continuity> Continuities { get; set; }
        public DbSet<CurrentWorkPlace> CurrentWorkPlaces { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PreviousWorkPlace> PreviousWorkPlaces { get; set; }
        public DbSet<Reason> Reasons { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<ShopPromotion> ShopPromotions { get; set; }
        public DbSet<WorkerPromotion> WorkerPromotions { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }

        public HrPrSystemDbContext(DbContextOptions<HrPrSystemDbContext> options) : base(options)
        {
        }

        public DbSet<HrPayrollSystemFinal.Viewmodels.ShopViewModel> ShopViewModel { get; set; }

        public DbSet<HrPayrollSystemFinal.Viewmodels.PositionViewModel> PositionViewModel { get; set; }

        public DbSet<HrPayrollSystemFinal.Viewmodels.CurrentWPViewModel> CurrentWPViewModel { get; set; }

        public DbSet<HrPayrollSystemFinal.Viewmodels.CompanyViewModel> CompanyViewModel { get; set; }

        public DbSet<HrPayrollSystemFinal.Viewmodels.AttendanceViewModel> AttendanceViewModel { get; set; }
    }
}
