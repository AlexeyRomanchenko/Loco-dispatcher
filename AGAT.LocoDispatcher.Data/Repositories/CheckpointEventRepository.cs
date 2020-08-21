using AGAT.LocoDispatcher.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Data.Repositories
{
    public class CheckpointEventRepository
    {
        private DatabaseContext _context;
        public CheckpointEventRepository()
        {
            _context = new DatabaseContext();
        }
        public async Task CreatAsync(CheckpointEvent _event)
        {
            _event.CreatedAt = DateTime.Now;
            _context.CheckpointEvents.Add(_event);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CheckpointEvent>> GetAsync()
        {
            return await _context.CheckpointEvents.ToListAsync();
        }
    }
}
