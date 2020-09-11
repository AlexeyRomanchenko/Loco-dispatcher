using AGAT.LocoDispatcher.RailData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.RailData.Repositories
{
    public class PlateRepository
    {
        public static RoutePlate GetPlateByRouteId(int id)
        {
            using (DataContext db = new DataContext())
            {
                return db.RoutePlates.AsNoTracking().Where(e => e.RailId == id).FirstOrDefault();
            }
        }
    }
}
