using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrPayrollSystemFinal.Utilities
{
    public static class SD
    {
        public enum Roles
        {
            Admin,
            Hr,
            Payroll,
            DepartmentHead,
            Worker
        }
        
        public const string Admin = "Admin";
        public const string Hr = "Hr";
        public const string Payroll = "Payroll";
        public const string DepartmentHead = "DepartmentHead";
        public const string Worker = "Worker";
    }
}
