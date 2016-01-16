using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace rv3.Areas.Manage.Models
{
    public class Reservation:Base
    {
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
        public Decimal Deposit { get; set; }

        [Display(Name = "Site")]
        public int SiteId { get; set; }

        [Display(Name = "Guest")]
        public int GuestId { get; set; }

        public Site Site { get; set; }
        public Guest Guest { get; set; }
    }
}
