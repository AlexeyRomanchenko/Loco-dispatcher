using AGAT.LocoDispatcher.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Data.Repositories
{
    public class EmergencyRepository
    {
        private DatabaseContext _context;
        public EmergencyRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(EmergencyEvent _event)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                _event.CreatedAt = DateTime.Now;
                context.EmergencyEvents.Add(_event);
                await context.SaveChangesAsync();
            }
        }
    }
}
