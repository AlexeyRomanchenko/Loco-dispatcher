using AGAT.LocoDispatcher.AsusDb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.AsusDb.Repositories
{
    public class RouteRepository
    {
        public IList<way> GetByCode(int parkId, string code)
        {
            if (!string.IsNullOrEmpty(code?.Trim()))
            {
                using (AsusContext _db = new AsusContext())
                {
                    return _db.way.Where(e => e.num_prk == code && e.prk_id == parkId).ToList();
                }
            }
            else
            {
                throw new ArgumentNullException("Code");
            }
        }

        public async Task<IList<int>> GetWayIdByCodeAsync(int parkId, string code)
        {
            try
            {
                if (string.IsNullOrEmpty(code?.Trim()))
                {
                    throw new ArgumentException("Код станции невалидный");
                }
                using (AsusContext context = new AsusContext())
                {
                    return await context.way.Where(e => e.num_prk == code && e.prk_id == parkId).Select(e => e.way_id).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
