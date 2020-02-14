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
    [Authorize(Roles = "Admin,Hr")]
    public class WorkplaceController : Controller
    {
        private readonly HrPrSystemDbContext _dbContext;
        public WorkplaceController(HrPrSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Current()
        {
            var data = await _dbContext.CurrentWorkPlaces.Include(x => x.Worker)
                                                            .Include(x => x.Company)
                                                                .Include(x => x.Department)
                                                                        .Include(x => x.Shop)
                                                                            .Include(x => x.Position).ToListAsync();
            return View(data);
        }

        [HttpGet]
        public IActionResult AddCurrent()
        {
           
            ViewBag.Companies = _dbContext.Companies;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCurrent(CurrentWPViewModel model)
        {
            ViewBag.Companies = _dbContext.Companies;

                if (ModelState.IsValid)
                {
                    CurrentWorkPlace current = new CurrentWorkPlace()
                    {
                        Id = model.Id,
                        WorkerId = model.WorkerId,
                        CompanyId = model.CompanyId,
                        DepartmentId = model.DepartmentId,
                        ShopId = model.ShopId,
                        PositionId = model.PositionId,
                        EntryDate = model.EntryDate,
                        ExitDate = model.ExitDate
                    };
                    await _dbContext.CurrentWorkPlaces.AddAsync(current);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Current));
                }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Previous()
        {
            var data = await _dbContext.PreviousWorkPlaces.Include(x => x.Worker).ToListAsync();
            return View(data);
        }                                                        


        public async Task<IActionResult> AddPrevious()
        {
            var workers = await _dbContext.Workers.ToListAsync();
            ViewBag.Workers = workers;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPrevious(PreviousWPViewModel model)
        {

            if (ModelState.IsValid)
            {
                PreviousWorkPlace previous = new PreviousWorkPlace()
                {
                    Id = model.Id,
                    WorkPlaceName = model.WorkPlaceName,
                    WorkerId = model.WorkerId,
                    EntryDate = model.EntryDate,
                    ExitDate = model.ExitDate,
                    ReasonOfTermination = model.ReasonOfTermination
                };

                await _dbContext.PreviousWorkPlaces.AddAsync(previous);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Previous));
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditPosition(int id)
        {
            var data = await _dbContext.CurrentWorkPlaces.FindAsync(id);
            if(data == null)
            {
                return Redirect("/Home/Error");
            }

            ViewBag.Workers = _dbContext.Workers;
            ViewBag.Companies = _dbContext.Companies;
            ViewBag.Departments = _dbContext.Departments;
            ViewBag.Shops = _dbContext.Shops;
            ViewBag.Positions = _dbContext.Positions;

            CurrentWPViewModel model = new CurrentWPViewModel()
            {
                Id = data.Id,
                WorkerId = data.WorkerId,
                CompanyId = data.CompanyId,
                Company = data.Company,
                DepartmentId = data.DepartmentId,
                ShopId = data.ShopId,
                PositionId = data.PositionId,
                EntryDate = data.EntryDate,
                ExitDate = data.ExitDate
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPosition (CurrentWPViewModel model)
        {
            ViewBag.Workers = _dbContext.Workers;
            ViewBag.Companies = _dbContext.Companies;
            ViewBag.Departments = _dbContext.Departments;
            ViewBag.Shops = _dbContext.Shops;
            ViewBag.Positions = _dbContext.Positions;

            if (ModelState.IsValid)
            {
                CurrentWorkPlace current = new CurrentWorkPlace()
                {
                    Id = model.Id,
                    WorkerId = model.WorkerId,
                    CompanyId = model.CompanyId,
                    Company = model.Company,
                    DepartmentId = model.DepartmentId,
                    ShopId = model.ShopId,
                    PositionId = model.PositionId,
                    EntryDate = model.EntryDate,
                    ExitDate = model.ExitDate
                };

                if (model.ExitDate != null)
                {
                    PreviousWorkPlace previous = new PreviousWorkPlace()
                    {
                        WorkerId = current.WorkerId,
                        WorkPlaceName = "Sinteks",
                        ReasonOfTermination = "Vəzifə dəyişikliyi",
                        EntryDate = current.EntryDate,
                        ExitDate = DateTime.Now
                    };
                    await _dbContext.PreviousWorkPlaces.AddAsync(previous);
                     _dbContext.CurrentWorkPlaces.Remove(current);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("Previous","Workplace");
                }
            }
            return View();
        }

    }


}