using AGAT.LocoDispatcher.RailData.Interfaces;
using AGAT.LocoDispatcher.RailData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.RailData.Repositories
{
    public class StationRepository : IStationRepository
    {
        private DataContext _context;
        public StationRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Station>> GetAsync()
        {
            return await _context.Stations.ToListAsync();
        }
        public async Task<Station> GetByCodeAsync(string code)
        {
            return await _context.Stations
                .Where(s => s.StationCode == code)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
