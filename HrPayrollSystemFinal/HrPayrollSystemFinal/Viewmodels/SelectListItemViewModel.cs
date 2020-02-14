using HrPayrollSystemFinal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPayrollSystemFinal.Viewmodels
{
    public class SelectListItemViewModel
    {
        public List<SelectListItem> SelectListWorker { get; set; }

        public Worker Worker { get; set; }


        public List<SelectListItem> SelectListCurrentWorkers { get; set; }

        public CurrentWorkPlace CurrentWorkPlace { get; set; }


        public List<SelectListItem> SelectListShops { get; set; }

        public Shop Shop { get; set; }


        public List<SelectListItem> SelectListCompanies { get; set; }

        public Company Company { get; set; }
    }
}
