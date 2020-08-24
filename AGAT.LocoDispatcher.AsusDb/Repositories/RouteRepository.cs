using AGAT.LocoDispatcher.AsusDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.AsusDb.Repositories
{
    public class RouteRepository
    {
        public IList<Route> GetByCode(int parkId, string code)
        {
            if (!string.IsNullOrEmpty(code?.Trim()))
            {
                using (AsusDbContext _db = new AsusDbContext())
                {
                    return _db.Routes.Where(e => e.ParkCode == code && e.ParkId == parkId).ToList();
                }
            }
            else
            {
                throw new ArgumentNullException("Code");
            }
        }
    }
}
