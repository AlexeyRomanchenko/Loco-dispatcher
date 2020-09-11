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
        public async Task<List<TrainDTO>> GetTrainsInfoByStationAndCodeAsync(int parkId, string parkCode)
        {
            try
            {
                if (string.IsNullOrEmpty(parkCode?.Trim()))
                {
                    throw new ArgumentNullException("Код парка не валидный");
                }
                using (AsusContext context = new AsusContext())
                {
                    List<TrainDTO> trains = await (from train in context.sostav
                                        join e in context.way on train.way_id equals e.way_id
                                        join w in context.train on train.sostav_id equals w.sostav_id 
                                        where e.prk_id == parkId && e.num_prk == parkCode
                                        select new TrainDTO()
                                        {
                                            TrainIndex = train.ind_s,
                                            HeadNumber = train.num_vag_h,
                                            TaleNumber = train.num_vag_t,
                                            Length = train.usl_dl_s,
                                            Weight = train.ves_s,
                                            RouteNumber = e.num_way,
                                            Type = w.sostav_id
                                        }).ToListAsync();
                    return trains;
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
