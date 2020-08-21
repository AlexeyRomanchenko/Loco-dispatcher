using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Constants
{
    public class EventConstants
    {
        public const string StartMoveEvent = "start_move";
        public const string StopMoveEvent = "stop_move";
        public const string PassCheckpoint = "passing_checkpoint";
        public const string StopOutsideStation = "stop_move_outside_station";
        public const string Emergency = "emergency";
        public const string StartShiftLocomotives = "start_shift_trains";
    }
}
