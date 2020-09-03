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
    }
}
