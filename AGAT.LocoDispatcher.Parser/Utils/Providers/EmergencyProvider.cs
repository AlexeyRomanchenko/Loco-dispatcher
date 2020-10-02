using AGAT.LocoDispatcher.Common.Interfaces;
using AGAT.LocoDispatcher.Parser.Utils.Events;
using AGAT.LocoDispatcher.Parser.Utils.Helpers;
using AGAT.LocoDispatcher.Parser.Utils.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AGAT.LocoDispatcher.Parser.Utils.Providers
{
    public class EmergencyProvider : IProvider
    {
        private DataManager _manager;
        private EventHelper helper;
        public EmergencyProvider(DataManager dataManager)
        {
            _manager = dataManager;
            helper = new EventHelper();
        }
        public void Create(IEvent _event)
        {
            try
            {

                EmergencyEvent emergencyEvent = (EmergencyEvent)_event;
                emergencyEvent.TrainId = LocoShiftHelper.TransformTrainNumber(emergencyEvent.TrainId);
                int shiftId = helper.GetLocoShiftIdByLocoNumber(emergencyEvent.TrainId).GetAwaiter().GetResult();
                Data.Models.EmergencyEvent emergency = new Data.Models.EmergencyEvent
                {
                    Type = emergencyEvent.Type,
                    CheckPointNumber = emergencyEvent.CheckPointNumber,
                    ShiftId = shiftId,
                    EmergencyStatus = emergencyEvent.EmergencyStatus,
                    EmergencyType = emergencyEvent.EmergencyType,
                    Message = emergencyEvent.Message,
                    Timestamp = emergencyEvent.Timestamp,
                    TrackNumber = emergencyEvent.TrackNumber
                };
                _manager.emergencyRepository.CreateAsync(emergency).GetAwaiter().GetResult();
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}