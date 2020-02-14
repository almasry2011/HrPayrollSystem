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
    public class ShopViewComponent : ViewComponent
    {
        private readonly HrPrSystemDbContext _dbContext;

        public ShopViewComponent(HrPrSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            SelectListItemViewModel viewModel = new SelectListItemViewModel
            {
                SelectListShops = await _dbContext.Shops.Select(d => new SelectListItem
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                }).ToListAsync(),
            };

            return View(viewModel);
        }
    }
}
