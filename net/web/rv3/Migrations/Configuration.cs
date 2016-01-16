namespace rv3.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using rv3.Areas.Manage.Models;
    using rv3.Infrastructure.Repositories;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //this.SeedSites(context);
            this.SeedGuests(context);
            //this.SeedReservations(context);
        }

        //private void SeedSites(rv3.Models.ApplicationDbContext context)
        //{
        //    short seederId = 1;
        //    //context.Sites.AddOrUpdate(x=> new { x.Comments,x.Has50Amp,x.IsAvailable,x.IsPullThrough,x.Lat,x.Long,x.Length,x.Number },
        //    context.Sites.AddOrUpdate(x => x.SeederId,
        //      new Site
        //      {
        //          SeederId = seederId++,
        //          Comments = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
        //          Has50Amp = true,
        //          IsAvailable = true,
        //          IsPullThrough = false,
        //          Lat = 49.1234,
        //          Long = 104.45,
        //          Length = 34,
        //          Number = 1
        //      },
        //      new Site
        //      {
        //          SeederId = seederId++,
        //          Comments = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
        //          Has50Amp = true,
        //          IsAvailable = true,
        //          IsPullThrough = false,
        //          Lat = 49.1234,
        //          Long = 104.45,
        //          Length = 36,
        //          Number = 2
        //      },
        //      new Site
        //      {
        //          SeederId = seederId++,
        //          Comments = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
        //          Has50Amp = true,
        //          IsAvailable = true,
        //          IsPullThrough = true,
        //          Lat = 49.1234,
        //          Long = 104.45,
        //          Length = 40,
        //          Number = 3
        //      },
        //      new Site
        //      {
        //          SeederId = seederId++,
        //          Comments = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
        //          Has50Amp = true,
        //          IsAvailable = true,
        //          IsPullThrough = true,
        //          Lat = 49.1234,
        //          Long = 104.45,
        //          Length = 24,
        //          Number = 5
        //      }
        //    );
        //    context.SaveChanges();

        //}
        private void SeedGuests(ApplicationDbContext context)
        {

            short seederId = 1;
            context.Guests.AddOrUpdate(x => x.SeederId,
              new Guest { SeederId = seederId++, Address = "2827 Headwater Drive, Fort Collins, CO", FirstName = "Robert", LastName = "Binckes" },
              new Guest { SeederId = seederId++, Address = "2827 Headwater Drive, Fort Collins, CO", FirstName = "Sue", LastName = "Smith" },
              new Guest { SeederId = seederId++, Address = "2827 Headwater Drive, Fort Collins, CO", FirstName = "Jane", LastName = "Doe" },
              new Guest { SeederId = seederId++, Address = "2827 Headwater Drive, Fort Collins, CO", FirstName = "Don", LastName = "Willy" }
            );
            context.SaveChanges();
        }
        //private void SeedReservations(rv3.Models.ApplicationDbContext context)
        //{
        //    short seederId = 1;
        //    context.Reservations.AddOrUpdate(x => x.SeederId,
        //      new Reservation
        //      {
        //          SeederId = seederId++,
        //          DateIn = DateTime.Now.AddDays(10),
        //          DateOut = DateTime.Now.AddDays(15),
        //          Deposit = 123,
        //          GuestId = context.Guests.Where(x => x.FirstName == "Sue").FirstOrDefault().Id,
        //          SiteId = context.Sites.Where(x => x.Number == 1).FirstOrDefault().Id
        //      },
        //      new Reservation
        //      {
        //          SeederId = seederId++,
        //          DateIn = DateTime.Now.AddDays(10),
        //          DateOut = DateTime.Now.AddDays(15),
        //          Deposit = 12,
        //          GuestId = context.Guests.Where(x => x.FirstName == "Robert").FirstOrDefault().Id,
        //          SiteId = context.Sites.Where(x => x.Number == 2).FirstOrDefault().Id
        //      },
        //      new Reservation
        //      {
        //          SeederId = seederId++,
        //          DateIn = DateTime.Now.AddDays(10),
        //          DateOut = DateTime.Now.AddDays(15),
        //          Deposit = 234,
        //          GuestId = context.Guests.Where(x => x.FirstName == "Don").FirstOrDefault().Id,
        //          SiteId = context.Sites.Where(x => x.Number == 3).FirstOrDefault().Id
        //      }

        //    );
        //    context.SaveChanges();
        //}
    }
}
