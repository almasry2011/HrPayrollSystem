using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HrPayrollSystemFinal.DAL;
using HrPayrollSystemFinal.Extensions;
using HrPayrollSystemFinal.Models;
using HrPayrollSystemFinal.Viewmodels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HrPayrollSystemFinal.Controllers
{
    [Authorize(Roles = "Payroll")]
    public class PayrollController : Controller
    {
        private readonly HrPrSystemDbContext _dbContext;
        public PayrollController(HrPrSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            var data =  _dbContext.CurrentWorkPlaces.Include(x => x.Worker)
                                                           .Include(x => x.Company)
                                                               .Include(x => x.Department)
                                                                     .Include(x=> x.Shop)
                                                                        .Include(x => x.Position).GetPaged(page, 10);
            return View(data);

        }
        

        public async Task<IActionResult> PaidSalaries()
        {
            var data = await _dbContext.Payrolls.Include(x=> x.Worker).Include(x=> x.Position).ToListAsync();
            return View(data);
        }

        public IActionResult List()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult List(int enteredMonth)
        {
            return View("PaidSalaries", ListByMonth(enteredMonth));
        }

        //Aya gore List edir
        public IQueryable<Payroll> ListByMonth(int enteredMonth)
        {
            return _dbContext.Payrolls.Include(x=> x.Worker).Include(x=> x.Position)
                                    .OrderBy(x => x.DateOfPaidSalaries).Where(x => x.DateOfPaidSalaries.Month == enteredMonth);
        }

        //Main SalaryCount
        public IActionResult SalaryCount(int id, int enteredMonth)
        {
            enteredMonth = DateTime.Now.Month; //indiki ay
            var year = DateTime.Now.Year; 
            var monthDay = DateTime.DaysInMonth(year, enteredMonth); //aydaki gunlerin sayi
            var day = DateTime.Now.Day; 

            //Get data from DB
            var data = _dbContext.
                CurrentWorkPlaces.Include(x => x.Worker).Include(x => x.Company)
                                                            .Include(x => x.Department)
                                                                .Include(x => x.Shop)
                                                                   .Include(x => x.Position)
                                                                        .Where(x => x.WorkerId == id).FirstOrDefault();
            if (data == null)
            {
                return Redirect("/Home/Error");
            }

            //Magazadan gelen bonus
            var shopBonus = _dbContext.ShopPromotions.Where(x => x.ShopId == data.ShopId && x.StartDate.Month == enteredMonth).FirstOrDefault();
            //Davamiyyetin sayi, nece gun ishe uzursuz sebebden gelmeyib.
            int attendence = _dbContext.Continuities
                                    .Where(x => x.WorkerId == id && x.Status == 0 && x.Reason == 0 && x.Date.Month == enteredMonth).Count();
            //Isci uzre bonusun yoxlanmasi
            var bonus = _dbContext.WorkerPromotions.Where(x => x.WorkerId == id && x.Date.Month == enteredMonth).FirstOrDefault();
            //Isci uzre mezuniyyetin yoxlanmasi
            var holiday = _dbContext.Vacations.Where(x => x.WorkerId == id && x.VacationStarted.Month == enteredMonth).FirstOrDefault();

            decimal salaryForDay = Math.Truncate(data.Position.Salary / 31); //1 gune ne qeder pul dusur
            
            decimal SalaryForRealDate = Math.Truncate((data.Position.Salary * day) / monthDay); // ayin tarixine gore hesablama

            //bonus ve tetil yoxdursa ve magaza bonusu yoxdursa
            if (bonus == null && holiday == null && shopBonus == null)
            {
                return AbsentOnly(monthDay, day, data, attendence, salaryForDay, SalaryForRealDate);
            }

            else //bonus var ve tetil yoxdursa ve magaza yoxdursa
                if (bonus != null && holiday == null && shopBonus == null)
            {
                return BonusOnly(monthDay, day, data, attendence, bonus, salaryForDay, SalaryForRealDate);
            }

            else //bonus yoxdur ve tetil varsa ve magaza yoxdursa
                if (bonus == null && holiday != null && shopBonus == null)
            {
                return VacationOnly(monthDay, day, data, attendence, holiday, salaryForDay, SalaryForRealDate);
            }

            else //bonus var ve tetil var ve magaza yoxdursa
                if (bonus != null && holiday != null && shopBonus == null)
            {
                return BonusAndVacation(monthDay, day, data, attendence, bonus, holiday, salaryForDay, SalaryForRealDate);
            }

            else //bonus yox ve tetil yoxdursa ve magaza varsa
                if (bonus == null && holiday == null && shopBonus != null)
            {
                return ShopBonusOnly(monthDay, day, data, shopBonus, attendence, salaryForDay, SalaryForRealDate);
            }

            else //bonus var ve tetil yoxdursa ve magaza varsa
                if (bonus != null && holiday == null && shopBonus != null)
            {
                return BonusAndShopBonus(monthDay, day, data, shopBonus, attendence, bonus, salaryForDay, SalaryForRealDate);
            }

            else //bonus yoxdur ve tetil varsa ve magaza varsa
                if (bonus == null && holiday != null && shopBonus != null)
            {
                return VacationAndShopBonus(monthDay, day, data, shopBonus, attendence, holiday, salaryForDay, SalaryForRealDate);
            }

            else //bonus var ve tetil var ve magaza var
                if (bonus != null && holiday != null && shopBonus != null)
            {
                return AllInOne(monthDay, day, data, shopBonus, attendence, bonus, holiday, salaryForDay, SalaryForRealDate);
            }

            return View();
        }

        #region Methods for SalaryCount

        private IActionResult AllInOne(int monthDay, int day, CurrentWorkPlace data, ShopPromotion shopBonus, int attendence, WorkerPromotion bonus, Vacation holiday, decimal salaryForDay, decimal SalaryForRealDate)
        {
            var absentDaysSalary = attendence * salaryForDay;
            var shpBonus = shopBonus.Reward;
            var awardForWorker = bonus.Reward;
            var tetilihesabla = (holiday.VacationEnded - holiday.VacationStarted);
            var tetilBonus = tetilihesabla.Days / 2;
            var tetilTotal = (tetilBonus * salaryForDay);
            var TotalSalary = SalaryForRealDate - absentDaysSalary + shpBonus + tetilTotal + awardForWorker;
            PayrollViewModel payrollView = new PayrollViewModel()
            {
                WorkerId = data.WorkerId,
                Worker = data.Worker,
                PositionId = data.PositionId,
                Position = data.Position,
                VacationBonus = tetilTotal,
                CountofAbsentDays = attendence,
                WorkerPromotionId = bonus.Id,
                Bonus = bonus.Reward,
                ShopBonus = shpBonus,
                ShopPromotionId = shopBonus.Id,
                TotalSalary = TotalSalary
            };
            if (day == monthDay)
            {
                ConfigurePayrollViewModel(payrollView);
            }
            return View(payrollView);
        }

        private IActionResult VacationAndShopBonus(int monthDay, int day, CurrentWorkPlace data, ShopPromotion shopBonus, int attendence, Vacation holiday, decimal salaryForDay, decimal SalaryForRealDate)
        {
            var absentDaysSalary = attendence * salaryForDay;
            var shpBonus = shopBonus.Reward;
            var tetilihesabla = (holiday.VacationEnded - holiday.VacationStarted);
            var tetilBonus = tetilihesabla.Days / 2;
            var tetilTotal = (tetilBonus * salaryForDay);
            var TotalSalary = SalaryForRealDate - absentDaysSalary + shpBonus + tetilTotal;
            PayrollViewModel payrollView = new PayrollViewModel()
            {
                WorkerId = data.WorkerId,
                Worker = data.Worker,
                PositionId = data.PositionId,
                Position = data.Position,
                CountofAbsentDays = attendence,
                ShopBonus = shpBonus,
                ShopPromotionId = shopBonus.Id,
                VacationBonus = tetilTotal,
                TotalSalary = TotalSalary
            };
            if (day == monthDay)
            {
                ConfigurePayrollViewModel(payrollView);
            }
            return View(payrollView);
        }

        private IActionResult BonusAndShopBonus(int monthDay, int day, CurrentWorkPlace data, ShopPromotion shopBonus, int attendence, WorkerPromotion bonus, decimal salaryForDay, decimal SalaryForRealDate)
        {
            var absentDaysSalary = attendence * salaryForDay;
            var shpBonus = shopBonus.Reward;
            var awardForWorker = bonus.Reward;
            var TotalSalary = SalaryForRealDate - absentDaysSalary + shpBonus + awardForWorker;
            PayrollViewModel payrollView = new PayrollViewModel()
            {
                WorkerId = data.WorkerId,
                Worker = data.Worker,
                PositionId = data.PositionId,
                Position = data.Position,
                WorkerPromotionId = bonus.Id,
                Bonus = bonus.Reward,
                ShopBonus = shpBonus,
                ShopPromotionId = shopBonus.Id,
                CountofAbsentDays = attendence,
                TotalSalary = TotalSalary
            };
            if (day == monthDay)
            {
                ConfigurePayrollViewModel(payrollView);
            }

            return View(payrollView);
        }

        private IActionResult ShopBonusOnly(int monthDay, int day, CurrentWorkPlace data, ShopPromotion shopBonus, int attendence, decimal salaryForDay, decimal SalaryForRealDate)
        {
            var shpBonus = shopBonus.Reward;
            var absentDaysSalary = attendence * salaryForDay;
            var TotalSalary = SalaryForRealDate - absentDaysSalary + shpBonus;
            PayrollViewModel payrollView = new PayrollViewModel()
            {
                WorkerId = data.WorkerId,
                Worker = data.Worker,
                PositionId = data.PositionId,
                Position = data.Position,
                ShopBonus = shpBonus,
                ShopPromotionId = shopBonus.Id,
                CountofAbsentDays = attendence,
                TotalSalary = TotalSalary
            };
            if (day == monthDay)
            {
                ConfigurePayrollViewModel(payrollView);
            }
            return View(payrollView);
        }

        private IActionResult BonusAndVacation(int monthDay, int day, CurrentWorkPlace data, int attendence, WorkerPromotion bonus, Vacation holiday, decimal salaryForDay, decimal SalaryForRealDate)
        {
            decimal absentDaysSalary = attendence * salaryForDay;
            decimal awardForWorker = bonus.Reward;
            TimeSpan tetilihesabla = (holiday.VacationEnded - holiday.VacationStarted);
            int tetilBonus = tetilihesabla.Days / 2;
            decimal tetilTotal = (tetilBonus * salaryForDay);
            decimal TotalSalary = SalaryForRealDate - absentDaysSalary + tetilBonus + awardForWorker;

            PayrollViewModel payrollView = new PayrollViewModel()
            {
                WorkerId = data.WorkerId,
                Worker = data.Worker,
                PositionId = data.PositionId,
                Position = data.Position,
                VacationBonus = tetilTotal,
                CountofAbsentDays = attendence,
                WorkerPromotionId = bonus.Id,
                Bonus = bonus.Reward,
                TotalSalary = TotalSalary
            };
            if (day == monthDay)
            {
                ConfigurePayrollViewModel(payrollView);
            }
            return View(payrollView);
        }

        private IActionResult VacationOnly(int monthDay, int day, CurrentWorkPlace data, int attendence, Vacation holiday, decimal salaryForDay, decimal SalaryForRealDate)
        {
            decimal absentDaysSalary = attendence * salaryForDay;
            TimeSpan tetilihesabla = (holiday.VacationEnded - holiday.VacationStarted);
            int tetilBonus = tetilihesabla.Days / 2;
            decimal tetilTotal = (tetilBonus * salaryForDay);
            decimal TotalSalary = (SalaryForRealDate - absentDaysSalary) + tetilTotal;
            PayrollViewModel payrollView = new PayrollViewModel()
            {
                WorkerId = data.WorkerId,
                Worker = data.Worker,
                PositionId = data.PositionId,
                Position = data.Position,
                CountofAbsentDays = attendence,
                VacationBonus = tetilTotal,
                TotalSalary = TotalSalary
            };
            if (day == monthDay)
            {
                ConfigurePayrollViewModel(payrollView);
            }
            return View(payrollView);
        }

        private IActionResult BonusOnly(int monthDay, int day, CurrentWorkPlace data, int attendence, WorkerPromotion bonus, decimal salaryForDay, decimal SalaryForRealDate)
        {
            decimal absentDaysSalary = attendence * salaryForDay;
            decimal awardForWorker = bonus.Reward;
            decimal TotalSalary = SalaryForRealDate - absentDaysSalary + awardForWorker;
            PayrollViewModel payrollView = new PayrollViewModel()
            {
                WorkerId = data.WorkerId,
                Worker = data.Worker,
                PositionId = data.PositionId,
                Position = data.Position,
                WorkerPromotionId = bonus.Id,
                Bonus = bonus.Reward,
                CountofAbsentDays = attendence,
                TotalSalary = TotalSalary
            };
            if (day == monthDay)
            {
                ConfigurePayrollViewModel(payrollView);
            }
            return View(payrollView);
        }

        private IActionResult AbsentOnly(int monthDay, int day, CurrentWorkPlace data, int attendence, decimal salaryForDay, decimal SalaryForRealDate)
        {
            decimal absentDaysSalary = attendence * salaryForDay;
            //Bugunki Tarixe local tarixe gore hesablama
            //qaib ve bugunki tarixe gore hesablamag
            decimal TotalSalary = SalaryForRealDate - absentDaysSalary;

            PayrollViewModel payrollView = new PayrollViewModel()
            {
                WorkerId = data.WorkerId,
                Worker = data.Worker,
                PositionId = data.PositionId,
                Position = data.Position,
                CountofAbsentDays = attendence,
                TotalSalary = TotalSalary
            };
            if (day == monthDay)
            {
                ConfigurePayrollViewModel(payrollView);
            }
            return View(payrollView);
        }

        private void ConfigurePayrollViewModel(PayrollViewModel model)
        {
            var date = DateTime.Now.Date;
            Payroll payroll = new Payroll()
            {
                WorkerId = model.WorkerId,
                Worker = model.Worker,
                PositionId = model.PositionId,
                Position = model.Position,
                VacationBonus = model.VacationBonus,
                CountofAbsentDays = model.CountofAbsentDays,
                Bonus = model.Bonus,
                ShopBonus = model.ShopBonus,
                TotalSalary = model.TotalSalary,
                DateOfPaidSalaries = date
            };
            _dbContext.Payrolls.Add(payroll);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}