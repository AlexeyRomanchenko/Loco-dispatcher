using AGAT.locoDispatcher.ArchiveDB.Repositories;
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
    public class StartEventProvider : IProvider
    {
        private DataManager _manager;
        private EventHelper _helper;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public StartEventProvider(DataManager dataManager)
        {
            _manager = dataManager;
            _helper = new EventHelper();
        }
        public void Create(IEvent _event)
        {
            try
            {
                StartMoveEvent startMove = (StartMoveEvent)_event;
                startMove.TrainId = LocoShiftHelper.TransformTrainNumber(startMove.TrainId);
                int shiftId = _helper.GetLocoShiftIdByLocoNumber(startMove.TrainId).GetAwaiter().GetResult();
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
                EventModel model = new EventModel
                {
                    LocoNumber = startMove.TrainId,
                    Route = startMove.TrackNumber,
                    Type = startMove.Type,
                    Timestamp = startMove.Timestamp
                };
                logger.Info($"{DateTime.Now} | Start event Invoking ");
                _manager.startEventRepository.CreatAsync(moveEvent);
                _helper.InvokeEventToArchieveAsync(model, startMove.CheckPointNumber).GetAwaiter().GetResult();
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