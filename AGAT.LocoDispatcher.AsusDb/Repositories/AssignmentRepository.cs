using AGAT.LocoDispatcher.AsusDb.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.AsusDb.Repositories
{
    public class AssignmentRepository
    {
        private AsusContext context;
        public AssignmentRepository()
        {
            context = new AsusContext();
        }
        public async Task<IEnumerable<LokM_operWork>> GetActiveAsync()
        {
            return await context.LokM_operWork.AsNoTracking().Where(e => e.dt_end == null).ToListAsync();
        }
        public async Task<IEnumerable<LokM_operWork>> GetActiveByStationCodeAsync(string code)
        {
            return await context.LokM_operWork.AsNoTracking()
                .Where(e => e.dt_end == null && e.stanc == code && e.cod_work != "24" && e.cod_work != "25")
                .ToListAsync();
        }
    }
}
