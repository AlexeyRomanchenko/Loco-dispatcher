using AGAT.LocoDispatcher.AsusDb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.AsusDb.Repositories
{
    public class StationParkRepository

    {
        public IList<park> GetByCode(string code)
        {
            if (!String.IsNullOrEmpty(code.Trim()))
            {
                using (asusEntities context = new asusEntities())
                {
                    return context.park.Where(e => e.num_prk == code).ToList();
                }
            }
            else
            {
                throw new ArgumentNullException("Code error");
            }
        }

        public async Task<park> GetParkByStationAndCodeAsync(string station, string code)
        {
            try
            {
                using (asusEntities ctx = new asusEntities())
                {
                    park park = await ctx.park.Where(e=>e.stanc == station && e.num_prk == code).FirstOrDefaultAsync();
                    return park;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
