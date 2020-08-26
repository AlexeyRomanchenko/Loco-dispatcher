using AGAT.LocoDispatcher.AsusDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AGAT.LocoDispatcher.AsusDb.Repositories
{
    public class CarriageInfoRepository
    {
        public IList<vagon> GetByRouteId(int routeId)
        {
            try
            {
                using (asusEntities context = new asusEntities())
                {
                    return context.vagon.Where(e => e.way_id == routeId).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
