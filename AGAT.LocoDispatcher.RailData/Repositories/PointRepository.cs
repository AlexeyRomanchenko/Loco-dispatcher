using AGAT.LocoDispatcher.Common.Interfaces;
using AGAT.LocoDispatcher.Common.Models.EventModels;
using AGAT.LocoDispatcher.RailData.Helpers;
using AGAT.LocoDispatcher.RailData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
                        return await context.Points.AsNoTracking().Where(e => e.Code == checkpoint && e.ParkId == parkId).FirstOrDefaultAsync();
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
        public async Task<StationInfo> GetStationInfoByPointCode(string code)
        {
            try
            {
                if (string.IsNullOrEmpty(code))
                {
                    throw new ArgumentNullException($"code {code} is not valid");
                }
                using (DataContext context = new DataContext())
                {
                    var stationInfo =  await context.Points.Where(p => p.Code == code)
                        .Include(e=>e.Park)
                        .Join(context.Stations,
                        prk=> prk.Park.StationId,
                        station=>station.Id,
                        (_point, _st) => new StationInfo{
                            StationCode = _st.StationCode,
                            ParkId = _point.ParkId,
                            Route = _point.RouteCode
                        })
                        .AsNoTracking().FirstOrDefaultAsync();
                    if (string.IsNullOrEmpty(stationInfo.Route?.Trim()))
                    {
                        var _park = context.Parks.Where(p => p.Id == stationInfo.ParkId).FirstOrDefault();
                        stationInfo.Park = _park.Code;
                    }
                    else
                    {
                        stationInfo.Park = AggregateHelper.GetParkdCodeAndRoute(stationInfo.Route).Item1;
                        stationInfo.Route = AggregateHelper.GetParkdCodeAndRoute(stationInfo.Route).Item2;
                    }                   
                    return stationInfo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Point> GetPointByCodeAsync(string code)
        {
            try
            {
                if (string.IsNullOrEmpty(code?.Trim()))
                {
                    throw new ArgumentNullException("Point code is not valid");
                }
                using (DataContext context = new DataContext())
                {
                    return await context.Points.AsNoTracking().Where(e => e.Code == code).FirstOrDefaultAsync();
                }
            }
            catch 
            {
                throw;
            }
        }
    }
}
