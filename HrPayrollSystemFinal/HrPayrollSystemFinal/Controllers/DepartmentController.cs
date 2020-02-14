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
    
    public class DepartmentController : Controller
    {
        private readonly HrPrSystemDbContext _dbContext;
        public DepartmentController(HrPrSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var data = await _dbContext.Departments.Include(x => x.Company).ToListAsync();
            _dbContext.Departments.Include(x => x.Company).Include(x => x.CurrentWorkPlaces);
            return View(data);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var companies = await _dbContext.Companies.ToListAsync();
            ViewBag.Company = companies;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentViewModel model)
        {
            var companies = await _dbContext.Companies.ToListAsync();
            ViewBag.Company = companies;

            if (ModelState.IsValid)
            {
                Department department = new Department()
                {
                    Id = model.Id,
                    Name = model.Name,
                    CompanyId = model.CompanyId
                };
                await _dbContext.Departments.AddAsync(department);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Company = await _dbContext.Companies.ToListAsync();

            var data = await _dbContext.Departments.FindAsync(id);
            if (data == null)
            {
                return Redirect("/Home/Error");
            }

            DepartmentViewModel department = new DepartmentViewModel()
            {
                Id = data.Id,
                Name = data.Name,
                CompanyId = data.CompanyId
            };
            

            return View(department);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DepartmentViewModel model)
        {
            var companies = await _dbContext.Companies.ToListAsync();
            ViewBag.Company = companies;

            if (ModelState.IsValid)
            {
                Department department = new Department()
                {
                    Id = model.Id,
                    Name = model.Name,
                    CompanyId = model.CompanyId
                };
                _dbContext.Departments.Update(department);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }

            return View();
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _dbContext.Departments.Where(x => x.Id == id)
                                   .FirstOrDefaultAsync();
            _dbContext.Departments.Remove(department);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(List));
        }
    }
}