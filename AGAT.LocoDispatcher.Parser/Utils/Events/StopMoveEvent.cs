using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGAT.LocoDispatcher.Parser.Utils.Events
{
    public class StopMoveEvent : MoveEventBase
    {
        public StopMoveEvent(
            string type,
            int timestamp,
            double distance,
            string checkpointNumber,
            string trackNumber,
            string message,
            string trainId)
        {
            this.Type = type;
            this.Timestamp = timestamp;
            this.Distance = (int)distance;
            this.CheckPointNumber = checkpointNumber;
            this.TrackNumber = trackNumber;
            this.Message = message;
            this.TrainId = trainId;
        }
        public int Distance { get; set; }
    }
}