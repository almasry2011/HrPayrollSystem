using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrPayrollSystemFinal.Viewmodels
{
    public class EditWorkerViewModel : WorkerViewModel
    {
        public int Id { get; set; }

        public string ExistingPath { get; set; }
    }
}
