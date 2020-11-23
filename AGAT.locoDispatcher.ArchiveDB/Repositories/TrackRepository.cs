using AGAT.LocoDispatcher.Common.Interfaces;
using AGAT.LocoDispatcher.Common.Models.EventModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AGAT.locoDispatcher.ArchiveDB.Repositories
{
    public class TrackRepository
    {
        private arhieveEntities context;
        public TrackRepository()
        {
            context = new arhieveEntities();
        }

        public void InvokeEventAsync(IMoveEvent model, string trackerId)
        {
            try
            {
                if (model.Route?.Length < 2) 
                {
                    model.Route = $"0{model.Route}";
                }
                if (_routesToConvert.ContainsKey(model.Route))
                {
                   IStationInfo stationRoute = _routesToConvert.Where(e => e.Key == model.Route).Select(e=>e.Value).FirstOrDefault();
                    model.Park = stationRoute.Park;
                    model.Route = stationRoute.Route;
                }
                var timestamp = new SqlParameter("@timestamp", SqlDbType.DateTime);
                timestamp.Value = model.EventDateTime;
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
                var tracker = new SqlParameter("@num_uknb", SqlDbType.NVarChar);
                tracker.Value = trackerId;
                var distance = new SqlParameter("@km", SqlDbType.Int);
                distance.Value = model.Distance;
                
                if (string.IsNullOrEmpty(model.Park?.Trim()))
                {
                    return;
                }
                context.Database.ExecuteSqlCommand("exec LokM_Tracking @stanc, @timestamp,@num_lkmt, @park, @route, @rele, @km, @num_uknb", 
                    stationCode,timestamp, locomotiveNumber, park, route, type, distance, tracker);
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }

       
        private static Dictionary<string, IStationInfo> _routesToConvert = new Dictionary<string, IStationInfo>
        {
            {"3 (МЭТЗ)", new StationInfo 
                {
                    Park = "ЗВ",
                    Route = "04"
                }
            },
            {"1 (МЭТЗ)", new StationInfo
                {
                    Park = "ЗВ",
                    Route = "04"
                }
            },
            {"2 (МЗШ)", new StationInfo
                {
                    Park = "ЗВ",
                    Route = "03"
                }
            },
            {"8з", new StationInfo
                {
                    Park = "ЗВ",
                    Route = "08"
                }
            },
            {"7з", new StationInfo
                {
                    Park = "ЗВ",
                    Route = "07"
                }
            },
            {"5з", new StationInfo
                {
                    Park = "ЗВ",
                    Route = "05"
                }
            },
            {"4з", new StationInfo
                {
                    Park = "ЗВ",
                    Route = "04"
                }
            },
            {"1а", new StationInfo
                {
                    Park = "ГС",
                    Route = "01"
                }
            },
            {"20УП", new StationInfo
                {
                    Park = "ТЗ",
                    Route = ""
                }
            },
            {"ІІІАз", new StationInfo
                {
                    Park = "01",
                    Route = "03"
                }
            },
             {"ІІІз", new StationInfo
                {
                    Park = "01",
                    Route = "03"
                }
            },
              {"ІІІБз", new StationInfo
                {
                    Park = "01",
                    Route = "03"
                }
            },
             {"6ГП", new StationInfo
                {
                    Park = "01",
                    Route = "03"
                }
            },
            {"ІІ", new StationInfo
                {
                    Park = "01",
                    Route = "02"
                }
            },
             {"І", new StationInfo
                {
                    Park = "01",
                    Route = "01"
                }
            },

        };
    }
}
