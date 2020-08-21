using AGAT.LocoDispatcher.Common.Interfaces;
using AGAT.LocoDispatcher.Constants;
using AGAT.LocoDispatcher.Parser.Utils.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGAT.LocoDispatcher.Parser.Utils.Factories
{
    public class ProviderFactory
    {
        public IProvider GetProviderFactory(IEvent _event)
        {
            switch (_event.Type)
            {
                case EventConstants.StartMoveEvent:
                    return new StartEventProvider();
                case EventConstants.StopMoveEvent:
                    return new StopEventProvider();
                case EventConstants.StopOutsideStation:
                    return new StopEventProvider();
                case EventConstants.PassCheckpoint:
                    return new CheckpointProvider();
                case EventConstants.Emergency:
                    return new EmergencyProvider();
                case EventConstants.StartShiftLocomotives:
                    return new ShiftLocoProvider();
                default:
                    return null;
            }
        }
    }
}