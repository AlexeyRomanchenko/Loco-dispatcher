using AGAT.LocoDispatcher.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Common.Models
{
    public abstract class AbstractEvent: IMoveEvent
    {
        public string StationCode { get; set; }
        public string Park { get; set; }
        public string Route { get; set ; }
        public string Type { get ; set; }
        public string LocoNumber { get; set; }
        public int Timestamp { get; set; }
    }
}
