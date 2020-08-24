using AGAT.LocoDispatcher.AsusDb.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.AsusDb.Repositories
{
    public class AssignmentRepository
    {
        private AsusDbContext context;
        public AssignmentRepository()
        {
            context = new AsusDbContext();
        }
        public async Task<IEnumerable<Assignment>> GetActiveAsync()
        {
            return await context.Assignments.Where(e => e.EndDate == null).ToListAsync();
        }
        public async Task<IEnumerable<Assignment>> GetActiveByStationCodeAsync(string code)
        {
            return await context.Assignments.Where(e => e.EndDate == null && e.Station == code).ToListAsync();
        }
    }
}
