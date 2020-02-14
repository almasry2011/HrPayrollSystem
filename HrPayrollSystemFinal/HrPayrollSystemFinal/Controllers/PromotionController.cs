using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HrPayrollSystemFinal.DAL;
using Microsoft.EntityFrameworkCore;
using HrPayrollSystemFinal.Models;
using HrPayrollSystemFinal.Viewmodels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace HrPayrollSystemFinal.Controllers
{

    public class PromotionController : Controller
    {
        private readonly HrPrSystemDbContext _dbContext;
        public PromotionController(HrPrSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Authorize(Roles = "DepartmentHead,DHIT,DHMarketing,DHSales,DHBusinessDev")]
        [HttpGet]
        public async Task<IActionResult> WorkerPromotionList()
        {
            var data = await _dbContext.WorkerPromotions.Include(x => x.Worker)                                                            
                                                                .OrderBy(x=> x.Reward).ToListAsync();
            return View(data);
        }

        [Authorize(Roles = "DepartmentHead,DHIT,DHMarketing,DHSales,DHBusinessDev")]
        [HttpGet]
        public IActionResult WorkerPromotion()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> WorkerPromotion(WorkerPromotionViewModel model)
        {
            if (model.Date < DateTime.Now)
            {
                ModelState.AddModelError("Date", "Keçmiş tarixlərə bonus əlavə etmək olmaz");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    WorkerPromotion promotion = new WorkerPromotion()
                    {
                        Id = model.Id,
                        WorkerId = model.WorkerId,
                        Reward = model.Reward,
                        Date = model.Date
                    };
                    await _dbContext.WorkerPromotions.AddAsync(promotion);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("WorkerPromotionList");
                }
                
            }
                return View(model);
        }

        [Authorize(Roles = "DepartmentHead,DHIT,DHMarketing,DHSales,DHBusinessDev")]
        public async Task<IActionResult> Delete(int id)
        {
            var workerPromotions =  await _dbContext.WorkerPromotions.Where(x => x.Id == id).FirstOrDefaultAsync();
            _dbContext.WorkerPromotions.Remove(workerPromotions);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(WorkerPromotionList));
        }


        [Authorize(Roles = "Admin,Payroll")]
        [HttpGet]
        public async Task<IActionResult> ShopPromotionList()
        {
            var data = await _dbContext.ShopPromotions.Include(x=> x.Shop).ToListAsync();
            return View(data);
        }

        [HttpGet]
        public IActionResult ShopPromotion()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Payroll")]
        [HttpPost]
        public async Task<IActionResult> ShopPromotion(ShopPromotionViewModel model)
        {
            if (ModelState.IsValid)
            {
                ShopPromotion promotion = new ShopPromotion()
                {
                    Id = model.Id,
                    ShopId = model.ShopId,
                    Reward = model.Reward,
                    MaxAmount = model.MaxAmount,
                    MinAmount = model.MinAmount,
                    StartDate = model.StartDate,
                    FinishDate = model.FinishDate
                };
                await _dbContext.ShopPromotions.AddAsync(promotion);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(ShopPromotionList));
            }
            return View();
        }

        [Authorize(Roles = "Admin,Payroll")]
        public async Task<IActionResult> DeleteShop(int id)
        {
            var shopPromotion = await _dbContext.ShopPromotions.Where(x => x.Id == id).FirstOrDefaultAsync();
            _dbContext.ShopPromotions.Remove(shopPromotion);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(ShopPromotionList));
        }
    }
}