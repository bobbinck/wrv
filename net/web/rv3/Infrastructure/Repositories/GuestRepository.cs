using System;
using System.Collections.Generic;
using System.Linq;
using rv3.Areas.Manage.Models;
using System.Web;
using System.Linq.Expressions;
using System.Data.Entity;

namespace rv3.Infrastructure.Repositories
{
    public interface IGuestRepository
    {
        #region NonAsync

        /// <summary>
        /// Get all Guests
        /// </summary>
        IQueryable<Guest> All();

        /// <summary>
        /// Get all Guests where condition matches
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>IQueryable of Guests</returns>
        IQueryable<Guest> All(Expression<Func<Guest, bool>> match);

        /// <summary>
        /// Find Guest by id
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Guest</returns>
        Guest Find(int id);

        /// <summary>
        /// Finds Guest by condition.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Guest</returns>
        Guest Find(Expression<Func<Guest, bool>> match);

        /// <summary>
        /// Inserts or update Guest.
        /// </summary>
        /// <param name="model">The model.</param>
        void InsertOrUpdate(Guest model);

        /// <summary>
        /// Delete Guest.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void Delete(int id);

        /// <summary>
        /// Saves this instance.
        /// </summary>
        void Save();

        #endregion
    }

    public class GuestRepository : BaseRepository, IGuestRepository
    {
        public GuestRepository(ApplicationDbContext context) : base(context) { }

        #region NonAsync


        /// <summary>
        /// Get all Guests
        /// </summary>
        public IQueryable<Guest> All()
        {
            return _context.Guests;
        }

        /// <summary>
        /// Get all Guests where condition matches
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>
        /// IQueryable of Guests
        /// </returns>
        IQueryable<Guest> IGuestRepository.All(Expression<Func<Guest, bool>> match)
        {
            return _context.Guests.Where(match);
        }

        /// <summary>
        /// Find Guest by id
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Guest
        /// </returns>
        public Guest Find(int id)
        {
            return _context.Guests.SingleOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Finds Guest by condition.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>
        /// Guest
        /// </returns>
        public Guest Find(Expression<Func<Guest, bool>> match)
        {
            return _context.Guests.SingleOrDefault(match);
        }

        /// <summary>
        /// Inserts or update Guest.
        /// </summary>
        /// <param name="model">The model.</param>
        public void InsertOrUpdate(Guest model)
        {
            if (model.Id == 0)
            {
                _context.Guests.Add(model);
            }
            else
            {
                _context.Entry(model).State = EntityState.Modified;
            }
        }

        /// <summary>
        /// Delete Guest.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id)
        {
            var userToDelete = Find(id);
            _context.Guests.Remove(userToDelete);
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }

        #endregion

    }
}