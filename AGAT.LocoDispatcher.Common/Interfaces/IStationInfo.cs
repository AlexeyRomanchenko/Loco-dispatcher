using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Common.Interfaces
{
    public interface IStationInfo
    {
        string StationCode { get; set; }
        string Park { get; set; }
        string Route { get; set; }
    }
}
