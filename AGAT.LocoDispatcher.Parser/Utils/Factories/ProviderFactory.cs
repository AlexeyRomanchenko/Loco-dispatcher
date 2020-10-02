using AGAT.LocoDispatcher.Common.Interfaces;
using AGAT.LocoDispatcher.Constants;
using AGAT.LocoDispatcher.Parser.Utils.Managers;
using AGAT.LocoDispatcher.Parser.Utils.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGAT.LocoDispatcher.Parser.Utils.Factories
{
    public class ProviderFactory
    {
        private DataManager dataManager;
        public ProviderFactory(DataManager _dataManager)
        {
            dataManager = _dataManager;
        }
        public IProvider GetProviderFactory(IEvent _event)
        {
            switch (_event.Type)
            {
                case EventConstants.StartMoveEvent:
                    return new StartEventProvider(dataManager);
                case EventConstants.StopMoveEvent:
                    return new StopEventProvider(dataManager);
                case EventConstants.StopOutsideStation:
                    return new StopEventProvider(dataManager);
                case EventConstants.PassCheckpoint:
                    return new CheckpointProvider(dataManager);
                case EventConstants.Emergency:
                    return new EmergencyProvider(dataManager);
                case EventConstants.StartShiftLocomotives:
                    return new ShiftLocoProvider();
                default:
                    return null;
            }
        }
    }
}