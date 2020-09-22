using AGAT.locoDispatcher.ArchiveDB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.locoDispatcher.ArchiveDB.Repositories
{
    public class OperationRepository
    {
        private arhieveEntities context;
        public OperationRepository()
        {
            context = new arhieveEntities();
        }
        public async Task<Destination> GetOperationDestinationsByWorkIdAsync(int workId, DateTime? startDate) 
        {
            try
            {
                Destination destinations = await context.LokM_oper
                    .AsNoTracking()
                    .Where(e => e.lokM_work_id == workId && e.dt_beg == startDate)
                    .OrderByDescending(e=>e.lokM_oper_id)
                    .Select(e=> new Destination { 
                        From = e.pw_from,
                        To = e.pw_to
                    })
                    .FirstOrDefaultAsync();
                return destinations;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
