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
    
    public class ShopController : Controller
    {
        private readonly HrPrSystemDbContext _dbContext;
        public ShopController(HrPrSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        

        [Authorize(Roles = "Admin,Hr,DepartmentHead,Payroll")]
        [HttpGet]
        public IActionResult List(int page = 1)
        {
            var dataPage = _dbContext.Shops.Include(x=> x.Company).GetPaged(page, 10);
            return View(dataPage);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Companies = await _dbContext.Companies.ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ShopViewModel model)
        {
            ViewBag.Companies =  _dbContext.Companies;
            //ViewBag.Departments = await _dbContext.Departments.ToListAsync();

            if (ModelState.IsValid)
            {
                Shop newShop = new Shop()
                {
                    Id = model.Id,
                    Name = model.Name,
                    CompanyId = model.CompanyId,
                    DepartmentId = model.DepartmentId
                };
                await _dbContext.Shops.AddAsync(newShop);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit (int id)
        {
            var data = await _dbContext.Shops.FindAsync(id);
            ViewBag.Companies = await _dbContext.Companies.ToListAsync();
            ViewBag.Departments = _dbContext.Departments;

            if (data == null)
            {
                return Redirect("/Home/Error");
            }

            ShopViewModel shop = new ShopViewModel()
                {
                    Id = data.Id,
                    Name = data.Name,
                    CompanyId = data.CompanyId,
                    DepartmentId = data.DepartmentId
                };

            return View(shop);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ShopViewModel model)
        {
            var companies = await _dbContext.Companies.ToListAsync();
            ViewBag.Company = companies;

            if (ModelState.IsValid)
            {
                Shop newShop = new Shop()
                {
                    Id = model.Id,
                    Name = model.Name,
                    CompanyId = model.CompanyId,
                    DepartmentId = model.DepartmentId
                };
                _dbContext.Shops.Update(newShop);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }

            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var shop = await _dbContext.Shops.Where(x => x.Id == id)
                                   .FirstOrDefaultAsync();
            _dbContext.Shops.Remove(shop);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(List));
        }

    }
}