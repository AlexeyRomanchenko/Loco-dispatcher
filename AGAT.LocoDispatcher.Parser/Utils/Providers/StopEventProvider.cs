using AGAT.LocoDispatcher.Common.Interfaces;
using AGAT.LocoDispatcher.Common.Models.EventModels;
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
    public class StopEventProvider : IProvider
    {
        private DataManager _manager;
        private EventHelper _helper;
        public StopEventProvider()
        {
            _manager = new DataManager();
            _helper = new EventHelper();
        }
        public async Task Create(IEvent _event)
        {
            try
            {
                StopMoveEvent stopMove = (StopMoveEvent)_event;
                int shiftId = await _helper.GetLocoShiftIdByLocoNumber(stopMove.TrainId);
                Data.Models.StopMoveEvent stopMoveEvent = new Data.Models.StopMoveEvent
                {
                    Type = stopMove.Type,
                    CheckPointNumber = stopMove.CheckPointNumber,
                    Distance = stopMove.Distance,
                    ShiftId = shiftId,
                    Message = stopMove.Message,
                    Timestamp = stopMove.Timestamp,
                    TrackNumber = stopMove.TrackNumber
                };
                EventModel model = new EventModel
                {
                    LocoNumber = stopMove.TrainId,
                    DateTime = ConvertHelper.TimestampToDateTime(stopMove.Timestamp),
                    Route = stopMove.TrackNumber,
                    Type = stopMove.Type
                };
                await _manager.stopEventRepository.CreatAsync(stopMoveEvent);
                //await _helper.InvokeEventToArchieveAsync(model, stopMove.CheckPointNumber);
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