using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrTaabodi.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace DrTaabodi.Services
{
    public class WhichTableIsAffected
    {
        private readonly DrTaabodiDbContext _context;

        public WhichTableIsAffected(DrTaabodiDbContext context)
        {
            _context = context;
        }
        public ICollection<object> GetAfftectedCollection()
        {
            var dirtyEntries = _context.ChangeTracker
                .Entries()
                .Where(x => x.State == EntityState.Modified || x.State == EntityState.Deleted || x.State == EntityState.Added)
                .Select(x => x.Entity)
                .ToList();

            return dirtyEntries;
        }
    }
}
