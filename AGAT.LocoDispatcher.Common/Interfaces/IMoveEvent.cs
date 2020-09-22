using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Common.Interfaces
{
    public interface IMoveEvent : IEvent, IStationInfo
    {
        string LocoNumber { get; set; }
        int Distance{get;set;}
        DateTime EventDateTime { get; set; }
    }
}
