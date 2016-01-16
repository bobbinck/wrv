using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rv3.Areas.Manage.Models
{
    public class GuestViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public GuestViewModel() { }
        public GuestViewModel(Guest guest)
        {
            this.Id = guest.Id;
            this.FirstName = guest.FirstName;
            this.LastName = guest.LastName;
            this.Address = guest.Address;
        }
    }
}