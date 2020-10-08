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
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private DataManager _manager;
        private EventHelper _helper;
        public StopEventProvider(DataManager dataManager)
        {
            _manager = dataManager;
            _helper = new EventHelper();
        }
        public void Create(IEnumerable<IEvent> events)
        {
            try
            {
                logger.Info($"StopEvent Invoked start {DateTime.Now}");
                foreach (var stopEvent in events)
                {
                    StopMoveEvent stopMove = (StopMoveEvent)stopEvent;
                    stopMove.TrainId = LocoShiftHelper.TransformTrainNumber(stopMove.TrainId);
                    int shiftId = _helper.GetLocoShiftIdByLocoNumber(stopMove.TrainId).GetAwaiter().GetResult();
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
                        Route = stopMove.TrackNumber,
                        Type = stopMove.Type,
                        Distance = stopMove.Distance,
                        Timestamp = stopMove.Timestamp
                    };

                    _manager.stopEventRepository.CreatAsync(stopMoveEvent);
                    _helper.InvokeEventToArchieveAsync(model, stopMove.CheckPointNumber).GetAwaiter().GetResult();
                }
                _manager.stopEventRepository.Save();
                logger.Info($"StopEvent Invoked  {DateTime.Now}");
               
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