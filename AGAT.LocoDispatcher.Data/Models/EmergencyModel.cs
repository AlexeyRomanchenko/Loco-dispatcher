using AGAT.LocoDispatcher.Data.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Data.Models
{
    public class EmergencyEvent : MoveEventBase
    {
        public string EmergencyType { get; set; }
        public int EmergencyStatus { get; set; }

    }
}
