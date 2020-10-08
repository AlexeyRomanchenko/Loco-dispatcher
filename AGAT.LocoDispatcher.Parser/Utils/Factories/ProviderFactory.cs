using AGAT.LocoDispatcher.Common.Interfaces;
using AGAT.LocoDispatcher.Constants;
using AGAT.LocoDispatcher.Parser.Models;
using AGAT.LocoDispatcher.Parser.Utils.Managers;
using AGAT.LocoDispatcher.Parser.Utils.Providers;
using System.Collections;
using System.Collections.Generic;

namespace AGAT.LocoDispatcher.Parser.Utils.Factories
{
    public class ProviderFactory
    {
        private DataManager dataManager;
        public ProviderFactory(DataManager _dataManager)
        {
            dataManager = _dataManager;
        }
        public IProvider GetProviderFactory(string type)
        {
            switch (type)
            {
                case "StartEvent":
                    return new StartEventProvider(dataManager);
                case "StopEvent":
                    return new StopEventProvider(dataManager);
                case "CheckpointEvent":
                    return new CheckpointProvider(dataManager);
                case "EmergencyEvent":
                    return new EmergencyProvider(dataManager);
                case "LocoShiftEvent":
                    return new ShiftLocoProvider();
                default:
                    return null;
            }
        }

        public IEnumerable<IEvent> GetEventsFactory(string type, EventManager manager)
        {
            switch (type)
            {
                case "StartEvent":
                    return manager.StartEvent;
                case "StopEvent":
                    return manager.StopEvent;
                case "CheckpointEvent":
                    return manager.CheckpointEvent;
                case "EmergencyEvent":
                    return manager.EmergencyEvent;
                case "LocoShiftEvent":
                    return manager.LocoShiftEvent;
                default:
                    return null;
            }
        }
    }
}