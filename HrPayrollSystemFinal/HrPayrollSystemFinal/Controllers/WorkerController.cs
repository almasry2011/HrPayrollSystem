using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HrPayrollSystemFinal.DAL;
using HrPayrollSystemFinal.Viewmodels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HrPayrollSystemFinal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace HrPayrollSystemFinal.Controllers
{
    
    public class WorkerController : Controller
    {
        private readonly HrPrSystemDbContext _dbContext;
        private readonly IHostingEnvironment hostingEnvironment;

        public WorkerController(HrPrSystemDbContext dbContext, 
                                    IHostingEnvironment hostingEnvironment)
        {
            _dbContext = dbContext;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult LoadWorkers(int skip)
        {
            var model = _dbContext.Workers.OrderByDescending(p => p.Id).Skip(skip).Take(10);

            return PartialView("_WorkersPartial", model);
        }

        [Authorize(Roles = "Admin,Hr")]
        [HttpGet]
        public IActionResult List()
        {
            ViewBag.TotalCount = _dbContext.Workers.Count();
            var data = _dbContext.Workers.OrderByDescending(x => x.Id).Take(10);
            return View(data);
        }

        [Authorize(Roles = "Admin,Hr")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Hr")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkerViewModel model)
        {
            if (model.PassportExpirationDate <= DateTime.Now)
            {
                ModelState.AddModelError("PassportExpirationDate", "Passportunuzun son istifade tarixi bitmişdir");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    string uniqueFileName = ProcessUploadFile(model);
                    Worker newWorker = new Worker
                    {
                        Id = model.Id,
                        Name = model.Name,
                        Surname = model.Surname,
                        FatherName = model.FatherName,
                        BirthdayDate = model.BirthdayDate,
                        CurrentAdress = model.CurrentAdress,
                        DistrictRegistration = model.DistrictRegistration,
                        PassportNumber = model.PassportNumber.ToUpper(),
                        PassportExpirationDate = model.PassportExpirationDate,
                        EducationType = model.EducationType,
                        MartialStatus = model.MartialStatus,
                        Gender = model.Gender,
                        EmailAddress = model.EmailAddress,
                        PhotoPath = uniqueFileName
                    };

                    await _dbContext.Workers.AddAsync(newWorker);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(List));
                }
            }
            return View();
        }

        [Authorize(Roles = "Admin,Hr")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var workers = await _dbContext.Workers.FindAsync(id);
            EditWorkerViewModel workerViewModel = new EditWorkerViewModel()
            {
                Id = workers.Id,
                Name = workers.Name,
                Surname = workers.Surname,
                FatherName = workers.FatherName,
                BirthdayDate = workers.BirthdayDate,
                CurrentAdress = workers.CurrentAdress,
                DistrictRegistration = workers.DistrictRegistration,
                PassportNumber = workers.PassportNumber,
                PassportExpirationDate = workers.PassportExpirationDate,
                EducationType = workers.EducationType,
                MartialStatus = workers.MartialStatus,
                Gender = workers.Gender,
                EmailAddress = workers.EmailAddress,
                ExistingPath = workers.PhotoPath
            };

            //Yoxladim
            if(workers == null)
            {
                return Redirect("/Home/Error");
            }

            return View(workerViewModel);
        }

        [Authorize(Roles = "Admin,Hr")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditWorkerViewModel model)
        {
            if (model.PassportExpirationDate <= DateTime.Now)
            {
                ModelState.AddModelError("PassportExpirationDate", "Passportunuzun son istifade tarixi bitmişdir");
            }

            else
            {
                if (ModelState.IsValid)
                {
                    var workers = await _dbContext.Workers.FindAsync(model.Id);
                    workers.Name = model.Name;
                    workers.Surname = model.Surname;
                    workers.FatherName = model.FatherName;
                    workers.BirthdayDate = model.BirthdayDate;
                    workers.CurrentAdress = model.CurrentAdress;
                    workers.DistrictRegistration = model.DistrictRegistration;
                    workers.PassportNumber = model.PassportNumber;
                    workers.PassportExpirationDate = model.PassportExpirationDate;
                    workers.EducationType = model.EducationType;
                    workers.MartialStatus = model.MartialStatus;
                    workers.EmailAddress = model.EmailAddress;
                    workers.Gender = model.Gender;
                    if(model.Photo != null)
                    {
                        if(model.ExistingPath != null)
                        {
                            string filePath = Path.Combine(hostingEnvironment.WebRootPath,
                                                                "workerImages", model.ExistingPath);
                            System.IO.File.Delete(filePath);
                        }
                        workers.PhotoPath = ProcessUploadFile(model);
                    }

                    _dbContext.Workers.Update(workers);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(List));
                }
            }
            return View();

        }

        [Authorize(Roles = "Admin,Hr,DepartmentHead,Payroll")]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var data = await _dbContext.Workers.FindAsync(id);
            if (data == null)
            {
                return Redirect("/Home/Error");
            }

            EditWorkerViewModel worker = new EditWorkerViewModel()
            {
                Id = data.Id,
                Name = data.Name,
                Surname = data.Surname,
                FatherName = data.FatherName,
                BirthdayDate = data.BirthdayDate,
                CurrentAdress = data.CurrentAdress,
                DistrictRegistration = data.DistrictRegistration,
                PassportNumber = data.PassportNumber.ToUpper(),
                PassportExpirationDate = data.PassportExpirationDate,
                EducationType = data.EducationType,
                MartialStatus = data.MartialStatus,
                Gender = data.Gender,
                EmailAddress = data.EmailAddress,
                ExistingPath = data.PhotoPath
            };

            return View(worker);
        }

        [Authorize(Roles = "Admin,Hr")]
        public async Task<IActionResult> Delete(EditWorkerViewModel model)
        {
            var workers = await _dbContext.Workers.FindAsync(model.Id);
            workers.Name = model.Name;
            workers.Surname = model.Surname;
            workers.FatherName = model.FatherName;
            workers.BirthdayDate = model.BirthdayDate;
            workers.CurrentAdress = model.CurrentAdress;
            workers.DistrictRegistration = model.DistrictRegistration;
            workers.PassportNumber = model.PassportNumber;
            workers.PassportExpirationDate = model.PassportExpirationDate;
            workers.EducationType = model.EducationType;
            workers.MartialStatus = model.MartialStatus;
            workers.Gender = model.Gender;
            workers.EmailAddress = model.EmailAddress;
            if (workers.PhotoPath != null)
            {
                string filePath = Path.Combine(hostingEnvironment.WebRootPath, "workerImages", workers.PhotoPath);
                System.IO.File.Delete(filePath);
            }

            _dbContext.Workers.Remove(workers);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

        [Authorize(Roles = "Admin,Hr,DepartmentHead")]
        public IActionResult CurrentWorkplaceDetails(int id)
        {
            var data = _dbContext.
                CurrentWorkPlaces.Include(x => x.Worker).Include(x => x.Company)
                                                            .Include(x => x.Department)
                                                                .Include(x => x.Shop)
                                                                   .Include(x => x.Position).Where(x => x.WorkerId == id).FirstOrDefault();
            if (data == null)
            {
                return Redirect("/Home/Error");
            }

            return View(data);
        }

        [Authorize(Roles = "Admin,Hr,DepartmentHead")]
        public IActionResult PreviousWorkplaceDetails(int id)
        {
            var data = _dbContext.
                PreviousWorkPlaces.Include(x => x.Worker).Where(x => x.WorkerId == id).FirstOrDefault();

            if (data == null)
            {
                return Redirect("/Home/Error");
            }

            return View(data);
        }


        private string ProcessUploadFile(WorkerViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "workerImages");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
        
    }
}