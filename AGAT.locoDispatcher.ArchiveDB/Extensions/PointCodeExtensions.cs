using AGAT.LocoDispatcher.Common.Interfaces;
using AGAT.LocoDispatcher.Common.Models.EventModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.locoDispatcher.ArchiveDB.Extensions
{
    public static class PointCodeExtensions
    {
        public static void CheckEdgeCheckpoint(this string pointCode, IMoveEvent moveEvent)
        {
            if (string.IsNullOrEmpty(pointCode?.Trim()))
            {
                return;
            }
            if (_edgePoints.ContainsKey(pointCode))
            {
                IStationInfo info = _edgePoints.Where(e => e.Key == pointCode).Select(e => e.Value).FirstOrDefault();
                moveEvent.Type = "edge_checkpoint";
                moveEvent.Park = info.Park;
                moveEvent.Route = info.Route;
            }
        }

        private static Dictionary<string, IStationInfo> _edgePoints = new Dictionary<string, IStationInfo>
        {
            // 744,745,761 - Контр точки, определяющие горку 
             { "745", new StationInfo
                {
                Park = "ГК",
                Route = "01"
                }
            },
             { "761", new StationInfo
                {
                Park = "ГК",
                Route = "01"
                }
            },
            { "744", new StationInfo
                {
                Park = "ГК",
                Route = "01"
                }
            },
            {
            "624", new StationInfo
                {
                Park = "01",
                Route = "01"
                }
            },
            {"625",new StationInfo
                {
                    Park = "01",
                    Route = "01"
                }
            },
            {"626",new StationInfo
                {
                    Park = "01",
                    Route = "01"
                }
            },
            {"627",new StationInfo
                {
                    Park = "01",
                    Route = "02"
                }
            },
            {"926",new StationInfo
                {
                    Park = "01",
                    Route = "03"
                }
            },
            {"925",new StationInfo
                {
                    Park = "ТЗ",
                    Route = "00"
                }
            },
            {"927",new StationInfo
                {
                    Park = "ЗВ",
                    Route = "00"
                }
            },
            {"791",new StationInfo
                {
                    Park = "ГС",
                    Route = "01"
                }
            }
        };
    }
}
