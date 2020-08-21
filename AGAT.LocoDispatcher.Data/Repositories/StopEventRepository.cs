using AGAT.LocoDispatcher.Constants;
using AGAT.LocoDispatcher.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Data.Repositories
{
    public class StopEventRepository
    {
        private DatabaseContext _context;
        public StopEventRepository()
        {
            _context = new DatabaseContext();
        }
        public async Task CreatAsync(StopMoveEvent _event)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                _event.CreatedAt = DateTime.Now;
                context.StopEvents.Add(_event);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<StopMoveEvent>> GetStopAsync()
        {
            return await _context.StopEvents.Where(e => e.Type == EventConstants.StopMoveEvent).ToListAsync();
        }

        public async Task<List<StopMoveEvent>> GetStopOutsideAsync()
        {
            return await _context.StopEvents.Where(e => e.Type == EventConstants.StopOutsideStation).ToListAsync();
        }
    }
}
