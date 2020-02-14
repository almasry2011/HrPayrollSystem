using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrPayrollSystemFinal.Models
{
    public class Reason
    {
        //public Reason()
        //{
        //    Continuities = new HashSet<Continuity>();
        //}

        public int Id { get; set; }
        [Required, StringLength(150)]
        public string ReasonName { get; set; }
        [Required]
        public bool ReasonType { get; set; }

        //public virtual ICollection<Continuity> Continuities  { get; set; }
    }
}
