using AGAT.LocoDispatcher.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Common.Models.EventModels
{
    public class StationInfo : IStationInfo
    {
        public string StationCode { get; set; }
        public string Park { get; set; }
        public string Route { get; set; }
    }
}
