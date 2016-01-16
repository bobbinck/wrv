using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTS.Helpers.Infrastructure.Logging;
using System.Data.Entity.Infrastructure;

namespace rv3.Infrastructure.Repositories
{
    public class BaseRepository
    {
        protected readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void Detach(object entity)
        {
            ((IObjectContextAdapter)_context).ObjectContext.Detach(entity);
        }

    }
}