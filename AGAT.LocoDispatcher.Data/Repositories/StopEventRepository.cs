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
        public StopEventRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void CreatAsync(StopMoveEvent _event)
        {
              try
              {
                        _event.CreatedAt = DateTime.Now;
                        _context.StopEvents.Add(_event);
                        _context.SaveChanges();
              }
              catch (Exception)
              {
                        throw;
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
