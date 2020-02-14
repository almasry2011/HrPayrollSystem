using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HrPayrollSystemFinal.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HrPayrollSystemFinal.Controllers
{
    public class AjaxController : Controller
    {
        private readonly HrPrSystemDbContext _dbContext;
        public AjaxController(HrPrSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IActionResult LoadDepartments (int? companyId)
        {
            if(companyId == null)
            {
                return Redirect("/Home/Error");
            }

            var data = _dbContext.Departments.Where(x => x.CompanyId == companyId).ToList();

            if(data == null)
            {
                return Redirect("/Home/Error");
            }

            return PartialView("_LoadDepartmentsPartialView", data);
        }

        public IActionResult LoadShops (int? departmentId)
        {
            var data = _dbContext.Shops.Where(x => x.DepartmentId == departmentId).ToList();

            return PartialView("_LoadShopsPartial", data);
        }

        public IActionResult LoadPositions(int? departmentId)
        {
            var data = _dbContext.Positions.Where(x => x.DepartmentId == departmentId).ToList();

            return PartialView("_LoadPositions", data);
        }
    }
}