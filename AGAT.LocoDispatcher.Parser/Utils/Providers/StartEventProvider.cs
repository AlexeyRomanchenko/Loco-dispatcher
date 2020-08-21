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
    public class StartEventProvider : IProvider
    {
        private DataManager _manager;
        private EventHelper _helper;
        public StartEventProvider()
        {
            _manager = new DataManager();
            _helper = new EventHelper();
        }
        public async Task Create(IEvent _event)
        {
            try
            {
                StartMoveEvent startMove = (StartMoveEvent)_event;
                int shiftId = await _helper.GetLocoShiftIdByLocoNumber(startMove.TrainId);
                Data.Models.StartMoveEvent moveEvent = new Data.Models.StartMoveEvent
                {
                    Type = startMove.Type,
                    CheckPointNumber = startMove.CheckPointNumber,
                    Direction = startMove.Direction,
                    DirectionParity = startMove.DirectionParity,
                    Timestamp = startMove.Timestamp,
                    ShiftId = shiftId,
                    TrackNumber = startMove.TrackNumber,
                    Message = startMove.Message
                };

                await _manager.startEventRepository.CreatAsync(moveEvent);
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