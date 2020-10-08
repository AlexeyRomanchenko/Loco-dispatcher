using AGAT.LocoDispatcher.Parser.Utils.Events;
using System.Collections.Generic;

namespace AGAT.LocoDispatcher.Parser.Models
{
    public class EventManager
    {
        public EventManager()
        {
            StartEvent = new List<StartMoveEvent>();
            StopEvent = new List<StopMoveEvent>();
            CheckpointEvent = new List<CheckpointEvent>();
            LocoShiftEvent = new List<ShiftLocomotiveEvent>();
            EmergencyEvent = new List<EmergencyEvent>();
        }
        public ICollection<StartMoveEvent> StartEvent { get; set; }
        public ICollection<StopMoveEvent> StopEvent { get; set; }
        public ICollection<CheckpointEvent> CheckpointEvent { get; set; }
        public ICollection<ShiftLocomotiveEvent> LocoShiftEvent { get; set; }
        public ICollection<EmergencyEvent> EmergencyEvent { get; set; }
    }
}