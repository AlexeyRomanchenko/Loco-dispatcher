using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGAT.LocoDispatcher.Parser.Utils.Events
{
    public class CheckpointEvent : MoveEventBase
    {
        public CheckpointEvent(string type,
            int timestamp,
            string trainId,
            int speed,
            string checkpointNumber,
            string trackNumber,
            string message
            )
        {
            this.Type = type;
            this.Timestamp = timestamp;
            this.TrainId = trainId;
            this.Speed = speed;
            this.CheckPointNumber = checkpointNumber;
            this.TrackNumber = trackNumber;
            this.Message = message;
        }
        public int Speed { get; set; }
    }
}