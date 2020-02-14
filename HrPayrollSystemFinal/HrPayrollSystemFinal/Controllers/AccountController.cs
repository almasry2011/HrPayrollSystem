using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HrPayrollSystemFinal.DAL;
using HrPayrollSystemFinal.Models;
using HrPayrollSystemFinal.Viewmodels;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using static HrPayrollSystemFinal.Utilities.SD;

namespace HrPayrollSystemFinal.Controllers
{
    public class AccountController : Controller
    {
        private readonly HrPrSystemDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(HrPrSystemDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        #region RolesAddAction
        //public async Task MyRolesAddedAction()
        //{
        //    if (!await _roleManager.RoleExistsAsync(Roles.Admin.ToString()))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
        //    }
        //    if (!await _roleManager.RoleExistsAsync(Roles.Hr.ToString()))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole(Roles.Hr.ToString()));
        //    }
        //    if (!await _roleManager.RoleExistsAsync(Roles.Payroll.ToString()))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole(Roles.Payroll.ToString()));
        //    }
        //    if (!await _roleManager.RoleExistsAsync(Roles.DepartmentHead.ToString()))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole(Roles.DepartmentHead.ToString()));
        //    }
        //    if (!await _roleManager.RoleExistsAsync(Roles.Worker.ToString()))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole(Roles.Worker.ToString()));
        //    }

        //}
        #endregion

        [Authorize(Roles = "Admin")]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    FirstName = model.Firstname,
                    LastName = model.Lastname,
                    UserName = model.Username,
                    Email = model.Email
                };

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(model);
                }
                await _userManager.AddToRoleAsync(user, Roles.Worker.ToString());

                await _signInManager.SignInAsync(user, true);

                SentMailToRegistered(user);


                return RedirectToAction("Index", "Home");

            }



            return View();
        }

        private static void SentMailToRegistered(ApplicationUser user)
        {
            //Qeydiyyatdan kecmish user'lere auto Email gonderilir
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("HrPayrollSystem", "systemhrpayroll@gmail.com"));
            //qeydiyyatda input'a daxil olunan email'e uygun olarag 
            message.To.Add(new MailboxAddress(user.UserName, user.Email));
            message.Subject = "Qeydiyyatdan keçdiniz";
            message.Body = new TextPart("plain")
            {
                Text = "Siz insan resurları və əmək haqqının hesablanması sistemində qeydiyyatdan keçdiniz."
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);//smtp hostu ve 587ci port
                client.Authenticate("systemhrpayroll@gmail.com", "HrPrSystem123");//email ve parol

                client.Send(message);
                client.Disconnect(true);
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var data = await _userManager.FindByEmailAsync(model.Email);
            if(data == null)
            {
                ModelState.AddModelError("", "Email ünvanı və ya Şifrə yanlışdır");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(data, model.Password, model.RememberMe, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Email ünvanı və ya Şifrə yanlışdır");
                return View(model);
            }
            return Redirect("/Home/Index");

        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/Account/Login");
        }
    }
}