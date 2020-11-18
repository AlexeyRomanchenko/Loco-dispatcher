using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGAT.LocoDispatcher.Parser.Utils.Events
{
    public class StartMoveEvent : MoveEventBase
    {
        public StartMoveEvent(
            string type,
            int timestamp,
            double direction,
            int directionParity,
            string message,
            string trainId,
            string trackNumber,
            string checkpointNumber
            )
        {
            this.Type = type;
            this.Direction = (int)direction;
            this.DirectionParity = directionParity;
            this.Message = message;
            this.Timestamp = timestamp;
            this.TrainId = trainId;
            this.TrackNumber = trackNumber;
            this.CheckPointNumber = checkpointNumber;
        }
        public int Direction { get; set; }
        public int DirectionParity { get; set; }
    }
}