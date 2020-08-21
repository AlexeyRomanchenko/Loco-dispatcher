using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGAT.LocoDispatcher.Parser.Utils.Events
{
    public class ShiftLocomotiveEvent : MoveEventBase
    {
        public ShiftLocomotiveEvent(string type, int timestamp, string esr, string message, List<string> trains)
        {
            this.Type = type;
            this.Timestamp = timestamp;
            this.ESR = esr;
            this.Message = message;
            this.Trains = trains;
        }
        public string ESR { get; set; }
        public IEnumerable<string> Trains { get; set; }
    }
}