using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace rv3.Areas.Manage.Models
{
    public class Site:Base
    {
        [Display(Name = "Site Number")]
        public int Number { get; set; }

        public double Lat { get; set; }

        public double Long { get; set; }

        [Display(Name = "Has 50A Service")]
        public bool Has50Amp { get; set; }

        public bool IsAvailable { get; set; }

        [Display(Name = "Pull-Through")]
        public bool IsPullThrough { get; set; }

        public int Length { get; set; }

        public String Comments { get; set; }
    }
}
