using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace rv3.Areas.Manage.Models
{
    public class Base
    {
        [Key]
        public int Id { get; set; }
        public short SeederId { get; set; }
    }
}