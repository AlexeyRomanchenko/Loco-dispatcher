using AGAT.LocoDispatcher.Common.Interfaces;
using AGAT.LocoDispatcher.Common.Models;
using AGAT.LocoDispatcher.Common.Models.EventModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.locoDispatcher.ArchiveDB.Repositories
{
    public class TrackRepository
    {
        private arhieveEntities context;
        public TrackRepository()
        {
            context = new arhieveEntities();
        }

        public async Task InvokeEventAsync(IMoveEvent model)
        {
            try
            {
                var timestamp = new SqlParameter("@timestamp", SqlDbType.DateTime);
                timestamp.Value = DateTime.Now;
                var stationCode = new SqlParameter("@stanc", SqlDbType.NVarChar);
                stationCode.Value = model.StationCode;
                var locomotiveNumber = new SqlParameter("@num_lkmt", SqlDbType.NVarChar);
                locomotiveNumber.Value = model.LocoNumber;
                var park = new SqlParameter("@park",SqlDbType.NVarChar);
                park.Value = model.Park;
                var route = new SqlParameter("@route", SqlDbType.Char);
                route.Value = model.Route;
                var type = new SqlParameter("@rele", SqlDbType.NVarChar);
                type.Value = model.Type;
                var res = await context.Database.ExecuteSqlCommandAsync("exec LokM_Tracking @stanc, @timestamp,@num_lkmt, @park, @route, @rele", stationCode,timestamp, locomotiveNumber, park, route, type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
