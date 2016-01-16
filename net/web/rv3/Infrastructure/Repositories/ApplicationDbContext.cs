using Microsoft.AspNet.Identity.EntityFramework;
using rv3.Models;
using System.Configuration;

namespace rv3.Infrastructure.Repositories
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base(ConfigurationManager.ConnectionStrings["AppContext"].ConnectionString, throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<rv3.Areas.Manage.Models.Guest> Guests { get; set; }
    }
}