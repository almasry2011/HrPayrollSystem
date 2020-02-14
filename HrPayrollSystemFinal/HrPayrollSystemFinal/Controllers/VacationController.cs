using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HrPayrollSystemFinal.DAL;
using HrPayrollSystemFinal.Models;
using HrPayrollSystemFinal.Viewmodels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HrPayrollSystemFinal.Controllers
{
    [Authorize(Roles = "Hr,Admin")]
    public class VacationController : Controller
    {
        private readonly HrPrSystemDbContext _dbContext;
        public VacationController(HrPrSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _dbContext.Vacations.Include(x => x.Worker).ToListAsync();
            return View(data);
        }
            
        [HttpGet]
        public IActionResult AddVacation()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddVacation(VacationViewModel model)
        {
            if (model.VacationStarted < DateTime.Now)
            {
                ModelState.AddModelError("VacationStarted", "Keçmiş tarixə əlavə etmək olmaz");
            }

            else
            {
                if(ModelState.IsValid)
                {
                        Vacation vacation = new Vacation()
                        {
                            Id = model.Id,
                            WorkerId = model.WorkerId,
                            VacationStarted = model.VacationStarted,
                            VacationEnded = model.VacationEnded
                        };
                        await _dbContext.Vacations.AddAsync(vacation);
                        await _dbContext.SaveChangesAsync();
                        return RedirectToAction("Index");
                    }
                }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var vacation = await _dbContext.Vacations.Where(x => x.Id == id)
                                   .FirstOrDefaultAsync();
            _dbContext.Vacations.Remove(vacation);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(List));
        }


        public IActionResult List()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult List(int enteredMonth)
        {
            return View("Index", ListByMonth(enteredMonth));
        }

        //Aya gore List edir
        public IQueryable<Vacation> ListByMonth(int enteredMonth)
        {
            return _dbContext.Vacations.Include(x => x.Worker)
                                                .OrderBy(x => x.VacationStarted)
                                                        .Where(x => x.VacationStarted.Month == enteredMonth);
        }
    }
}