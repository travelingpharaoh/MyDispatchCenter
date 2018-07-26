// ====================================================
// More Templates: https://www.ebenmonney.com/templates
// Email: support@ebenmonney.com
// ====================================================

using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories
{
    public class CasetRepository : Repository<Case>, ICaseRepository
    {
        public CasetRepository(DbContext context) : base(context)
        { }




        private gcsDbContext _appContext => (gcsDbContext)_context;
    }
}
