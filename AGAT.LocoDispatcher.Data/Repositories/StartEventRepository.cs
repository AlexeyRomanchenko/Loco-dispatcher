using AGAT.LocoDispatcher.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Data.Repositories
{
    public class StartEventRepository
    {
        private DatabaseContext _context;
        public StartEventRepository()
        {
            _context = new DatabaseContext();
        }
        public async Task CreatAsync(StartMoveEvent _event)
        {
            if (_event == null)
            {
                throw new ArgumentNullException("start event cant be null");
            }
           // await BeginEventAsync(_event);
            using (DatabaseContext context = new DatabaseContext())
            {
                _event.CreatedAt = DateTime.Now;
                context.StartEvents.Add(_event);
                await context.SaveChangesAsync();
            }
        }
        public async Task<List<StartMoveEvent>> GetAsync()
        {
            return await _context.StartEvents.ToListAsync();
        }
    }
}
