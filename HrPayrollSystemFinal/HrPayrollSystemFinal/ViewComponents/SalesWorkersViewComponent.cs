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
    public class SalesWorkersViewComponent : ViewComponent
    {
        private readonly HrPrSystemDbContext dbContext;

        public SalesWorkersViewComponent(HrPrSystemDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int salesDep = 11;
            SelectListItemViewModel viewModel = new SelectListItemViewModel
            {
                SelectListCurrentWorkers = await dbContext.CurrentWorkPlaces.Where(x => x.DepartmentId == salesDep).Select(d => new SelectListItem
                {
                    Text = d.Worker.Name + " " + d.Worker.Surname + " " + d.Worker.FatherName,
                    Value = d.Worker.Id.ToString()
                }).ToListAsync(),
            };

            return View(viewModel);
        }
    }
}
