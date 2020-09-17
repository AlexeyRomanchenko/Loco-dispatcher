using AGAT.LocoDispatcher.Common.Interfaces;
using AGAT.LocoDispatcher.RailData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.RailData.Repositories
{
    public class PointRepository : IRepository<Point>
    {
        public void Create(Point item)
        {
            try
            {
                using (DataContext context = new DataContext())
                {
                    context.Points.Add(item);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Point> GetById(int id)
        {
            try
            {
                if (id > 0)
                {
                    using (DataContext context = new DataContext())
                    {
                        return context.Points.AsNoTracking().Where(e => e.ParkId == id).ToList();
                    }
                }
                else
                {
                    throw new ArgumentNullException("Идентификатор парка невалиден");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Point> GetByCode(string checkpoint, int parkId)
        {
            try
            {
                if (!String.IsNullOrEmpty(checkpoint?.Trim()))
                {
                    using (DataContext context = new DataContext())
                    {
                        return await context.Points.AsNoTracking().Where(e => e.Code == checkpoint && e.ParkId == parkId).SingleOrDefaultAsync();
                    }
                }
                else
                {
                    throw new ArgumentNullException("point is nor valid");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task GetStationInfoByPointCode(string code)
        {
            try
            {
                if (string.IsNullOrEmpty(code))
                {
                    throw new ArgumentNullException($"code {code} is not valid");
                }
                using (DataContext context = new DataContext())
                {
                    var res = await context.Parks.Join(
                        context.Points,
                        park => park.ParkId,
                        point => point.ParkId,
                        (_park, _point) => new
                        {
                            StationId = _park.StationId,
                            Name = _park.Name,
                            ParkId = _park.ParkId
                        })
                        .Join(context.Stations,
                        park => park.StationId,
                        st => st.Id,
                        (park, st) => new 
                        {
                            stationCode = st.StationCode,
                            park = park.Name
                        }
                        )
                        .FirstOrDefaultAsync();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
