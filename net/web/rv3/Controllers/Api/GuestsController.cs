using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using rv3.Areas.Manage.Models;
using rv3.Models;
using rv3.Infrastructure.Repositories;
using DTS.Helpers.Infrastructure.Logging;

namespace rv3.Controllers.Api
{
    [RoutePrefix("api/guests")]

    public class GuestsController : ApiBaseController
    {

        //private ApplicationDbContext db = new ApplicationDbContext();
        private readonly IGuestRepository _guestRepository;

        public GuestsController(INLogger logger, IGuestRepository guestRepository)
            : base(logger)
        {
            _guestRepository = guestRepository;
        }


        // GET: api/Guests        
        [Route("")]
        public IQueryable<Guest> GetGuests()
        {
            return _guestRepository.All();
        }

        // GET: api/Guests/5
        [ResponseType(typeof(Guest))]
        [Route("{id:int}")]
        public IHttpActionResult GetGuest(int id)
        {
            Guest guest = _guestRepository.Find(id);
            if (guest == null)
            {
                return NotFound();
            }

            return Ok(guest);
        }

        // PUT: api/Guests/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGuest(int id, Guest guest)
        {
            return StatusCode(HttpStatusCode.MethodNotAllowed);
        }

        // POST: api/Guests
        [ResponseType(typeof(Guest))]
        public IHttpActionResult PostGuest(Guest guest)
        {
            return StatusCode(HttpStatusCode.MethodNotAllowed);
        }

        // DELETE: api/Guests/5
        [ResponseType(typeof(Guest))]
        public IHttpActionResult DeleteGuest(int id)
        {
            return StatusCode(HttpStatusCode.MethodNotAllowed);
        }

        // GET: api/guests/pageSize/pageNumber
        [Route("{draw:int}/{pageSize:int}/{start:int}")]
        public IHttpActionResult Get(int draw, int pageSize, int start)
        {
            var searchValue = Url.Request.GetQueryNameValuePairs().Where(x => x.Key == "searchValue").FirstOrDefault().Value;
            var orderBy = Url.Request.GetQueryNameValuePairs().Where(x => x.Key == "orderBy").FirstOrDefault().Value;

            searchValue = Uri.UnescapeDataString(searchValue);
            orderBy = Uri.UnescapeDataString(orderBy);

            var filteredData = this.GetGuests().ToList().Select(x => new GuestViewModel(x)).AsQueryable();
            var totalCount = filteredData.Count();

            //order the data
            if (!string.IsNullOrEmpty(orderBy)) { filteredData = filteredData.OrderBy(orderBy); }

            //search the data
            if (!string.IsNullOrEmpty(searchValue))
            {
                filteredData = filteredData.Where(x =>
                        x.FirstName.ToLower().Contains(searchValue) ||
                        x.LastName.ToLower().Contains(searchValue) ||
                        x.Address.ToLower().Contains(searchValue));
            }

            //paginate the data
            var pagedData = filteredData.Skip(start)
                                    .Take(pageSize)
                                    .ToList();

            //send back datatable.net response
            var result = new 
            {
                draw = draw,
                recordsTotal = totalCount,
                recordsFiltered = filteredData.Count(),
                data = pagedData
            };

            return Ok(result);
        }
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool GuestExists(int id)
        {
            return _guestRepository.All().Any(e => e.Id == id);
        }
    }
}