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
    [Authorize(Roles = "Admin, Hr")]
    public class PositionController : Controller
    {
        private readonly HrPrSystemDbContext _dbContext;
        public PositionController(HrPrSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> List()
        {
            var data = await _dbContext.Positions.Include(x => x.Company).Include(x => x.Department).ToListAsync();
            return View(data);

        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //ViewBag.Departments = await _dbContext.Departments.ToListAsync();
            ViewBag.Companies = await _dbContext.Companies.ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PositionViewModel model)
        {
            ViewBag.Companies = await _dbContext.Companies.ToListAsync();

            if (ModelState.IsValid)
            {
                Position position = new Position()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Salary = model.Salary,
                    CompanyId = model.CompanyId,
                    DepartmentId = model.DepartmentId
                };
                await _dbContext.Positions.AddAsync(position);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _dbContext.Positions.FindAsync(id);
            if(data == null)
            {
                return Redirect("/Home/Error");
            }

            ViewBag.Companies = _dbContext.Companies;
            ViewBag.Departments = _dbContext.Departments;

            PositionViewModel model = new PositionViewModel()
            {
                Id = data.Id,
                Name = data.Name,
                CompanyId = data.CompanyId,
                DepartmentId = data.DepartmentId,
                Salary = data.Salary
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PositionViewModel model)
        {
            ViewBag.Companies = await _dbContext.Companies.ToListAsync();

            if (ModelState.IsValid)
            {
                Position newPosition = new Position()
                {
                    Id = model.Id,
                    Name = model.Name,
                    CompanyId = model.CompanyId,
                    DepartmentId = model.DepartmentId,
                    Salary = model.Salary
                };
                _dbContext.Positions.Update(newPosition);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var shop = await _dbContext.Positions.Where(x => x.Id == id)
                                   .FirstOrDefaultAsync();
            _dbContext.Positions.Remove(shop);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(List));
        }
    }
}