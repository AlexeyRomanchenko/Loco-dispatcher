using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGAT.LocoDispatcher.Parser.Utils.Events
{
    public class EmergencyEvent : MoveEventBase
    {
        public EmergencyEvent(
            string type,
            int timestamp,
            string trainId,
            string emergencyType,
            int emergencyStatus,
            string message)
        {
            this.Type = type;
            this.Timestamp = timestamp;
            this.TrainId = trainId;
            this.EmergencyType = emergencyType;
            this.EmergencyStatus = emergencyStatus;
            this.Message = message;
        }
        public string EmergencyType { get; set; }
        public int EmergencyStatus { get; set; }

    }
}