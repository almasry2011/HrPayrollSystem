using HrPayrollSystemFinal.DAL;
using HrPayrollSystemFinal.Viewmodels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrPayrollSystemFinal.ViewComponents
{
    public class EmployeeViewComponent : ViewComponent
    {
        private readonly HrPrSystemDbContext dbContext;

        public EmployeeViewComponent(HrPrSystemDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            SelectListItemViewModel viewModel = new SelectListItemViewModel
            {
                SelectListWorker = await dbContext.Workers.Select(d => new SelectListItem
                {
                    Text = d.Name + " " + d.Surname + " " + d.FatherName,
                    Value = d.Id.ToString()
                }).ToListAsync(),
            };

            return View(viewModel);
        }
    }
}
