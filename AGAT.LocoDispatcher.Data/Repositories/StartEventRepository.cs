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
        private DatabaseContext context;
        public StartEventRepository(DatabaseContext _context)
        {
            context = _context;
        }
        public void CreatAsync(StartMoveEvent _event)
        {
            if (_event == null)
            {
                throw new ArgumentNullException("start event cant be null");
            }
            try
             {
                _event.CreatedAt = DateTime.Now;
                context.StartEvents.Add(_event);
                context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
        }
        public async Task<List<StartMoveEvent>> GetAsync()
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    return await context.StartEvents.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
