using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HrPayrollSystemFinal.DAL;
using Microsoft.EntityFrameworkCore;
using HrPayrollSystemFinal.Viewmodels;
using HrPayrollSystemFinal.Models;
using HrPayrollSystemFinal.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using MimeKit;
using MailKit.Net.Smtp;
using HrPayrollSystemFinal.Extensions;

namespace HrPayrollSystemFinal.Controllers
{
    [Authorize(Roles = "Hr,Admin")]
    public class AttendanceController : Controller
    {
        private readonly HrPrSystemDbContext _dbContext;
        public AttendanceController(HrPrSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AttendanceViewModel model)
        {
            
            if(model.Date > DateTime.Now)
            {
                ModelState.AddModelError("Date", "Gələcək tarixə qeyd aparmaq olmaz");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    Continuity continuity = new Continuity()
                    {
                       Id = model.Id,
                       WorkerId = model.WorkerId,
                       Date = model.Date,
                       Reason = model.Reason,
                       Status = model.Status,
                       ReasonName = model.ReasonName
                    };
                    await _dbContext.Continuities.AddAsync(continuity);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
               
            return View();
        }

        //
        public async Task<IActionResult> Index()
        {
            var data = await _dbContext.Continuities.Include(x => x.Worker).OrderBy(x => x.Date).ToListAsync();

            return View(data);
        }

        public IActionResult List()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult List(int enteredMonth)
        {
            return View("Index", ListByMonth(enteredMonth));
        }

        //Aya gore List edir
        public IQueryable<Continuity> ListByMonth(int enteredMonth)
        {
            return _dbContext.Continuities.Include(x => x.Worker).OrderBy(x => x.Date).Where(x=> x.Date.Month == enteredMonth);
        }

        //Qaib limitini yoxlamag
        public IActionResult WorkerAttendance(int id)
        {
            var month = DateTime.Now.Month;

            var attendance = _dbContext.Continuities.
                                        Where(x => x.WorkerId == id && x.Status == 0 && x.Reason == 0 && x.Date.Month == month).Count();
            var data = _dbContext.Workers.Where(x => x.Id == id).FirstOrDefault();

            if (attendance >= 5)
            {
                SentMail(attendance, data);
            }
            return RedirectToAction(nameof(Index));

        }

        private static void SentMail(int attendance, Worker data)
        {
            //user'lere auto Email gonderilir
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("HrPayrollSystem", "systemhrpayroll@gmail.com"));
            //qeydiyyatda input'a daxil olunan email'e uygun olarag 
            message.To.Add(new MailboxAddress(data.Name, data.EmailAddress));
            message.Subject = "HR xəbərdarlıq";
            message.Body = new TextPart("plain")
            {
                Text = $"Sizin HR tərəfindən {DateTime.Now.ToShortDateString()} üçün qaib limitiniz yoxlanıldı və ay ərzində qaib sayınız {attendance}'dir. Qaib sayi 5-dən çox olduğu üçün xəbərdarlıq olunursunuz."
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);//smtp hostu ve 587ci port
                client.Authenticate("systemhrpayroll@gmail.com", "HrPrSystem123");//email ve parol

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}