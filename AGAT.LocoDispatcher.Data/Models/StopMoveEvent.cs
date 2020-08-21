using AGAT.LocoDispatcher.Data.Events;

namespace AGAT.LocoDispatcher.Data.Models
{
    public class StopMoveEvent : MoveEventBase
    {
        public int Distance { get; set; }
    }
}
