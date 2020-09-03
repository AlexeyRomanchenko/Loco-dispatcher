using AGAT.LocoDispatcher.AsusDb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.AsusDb.Repositories
{
    public class TrainRepository
    {
        public async Task<List<TrainDTO>> GetTrainsInfoByWayIdsAsync(IList<int> wayIds)
        {
            try
            {
                if (wayIds.Count() > 0)
                {
                    IList<int?> _ids = new List<int?>();
                    foreach (int wayId in wayIds)
                    {
                        int? _wayId = (int?)wayId;
                        _ids.Add(_wayId);
                    }
                    using (AsusContext context = new AsusContext())
                    {
                        return await context.sostav.Where(w => _ids.Contains(w.way_id)).Select(e=> new TrainDTO ()
                        { 
                            TrainIndex = e.ind_s,
                            HeadNumber = e.num_vag_h,
                            TaleNumber = e.num_vag_t,
                            Length= e.usl_dl_s,
                            Weight= e.ves_s 
                        }).ToListAsync();
                    }
                }
                else 
                {
                    throw new ArgumentNullException("Way Id не валидный. Произошла ошибка");
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
