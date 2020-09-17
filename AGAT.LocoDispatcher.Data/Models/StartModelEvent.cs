using AGAT.LocoDispatcher.Common.Interfaces;
using AGAT.LocoDispatcher.Data.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Data.Models
{
    public class StartMoveEvent : MoveEventBase
    {
        public int Direction { get; set; }
        public int? DirectionParity { get; set; }
    }
}
