using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HrPayrollSystemFinal.Models;
using HrPayrollSystemFinal.DAL;
using Microsoft.AspNetCore.Authorization;

namespace HrPayrollSystemFinal.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly HrPrSystemDbContext _dbContext;
        public HomeController(HrPrSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Error()
        {
            return View();
        }
        
        public IActionResult Index()
        {
            ViewBag.TotalWorkersCount = _dbContext.Workers.Count();
            ViewBag.TotalCurrentWorkersCount = _dbContext.CurrentWorkPlaces.Count();
            ViewBag.TotalDepartmentCount = _dbContext.Departments.Count();
            ViewBag.TotalShopCount = _dbContext.Shops.Count();
            ViewBag.TotalCompanyCount = _dbContext.Companies.Count();
            ViewBag.TotalPositionsCount = _dbContext.Positions.Count();
            return View();
        }
    }
}
