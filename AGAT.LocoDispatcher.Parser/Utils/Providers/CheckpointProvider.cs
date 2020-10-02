using AGAT.LocoDispatcher.Common.Interfaces;
using AGAT.LocoDispatcher.Common.Models.EventModels;
using AGAT.LocoDispatcher.Parser.Utils.Events;
using AGAT.LocoDispatcher.Parser.Utils.Helpers;
using AGAT.LocoDispatcher.Parser.Utils.Managers;
using System;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Parser.Utils.Providers
{
    public class CheckpointProvider : IProvider
    {
        private DataManager _manager;
        private EventHelper helper;
        public CheckpointProvider(DataManager dataManager)
        {
            _manager = dataManager;
            helper = new EventHelper();
        }
        public void Create(IEvent _event)
        {
            try
            {
                CheckpointEvent checkpointEvent = (CheckpointEvent)_event;
                checkpointEvent.TrainId = LocoShiftHelper.TransformTrainNumber(checkpointEvent.TrainId);
                int shiftId = helper.GetLocoShiftIdByLocoNumber(checkpointEvent.TrainId).GetAwaiter().GetResult();
                Data.Models.CheckpointEvent checkpoint = new Data.Models.CheckpointEvent
                {
                    Type = checkpointEvent.Type,
                    CheckPointNumber = checkpointEvent.CheckPointNumber,
                    Message = checkpointEvent.Message,
                    Speed = checkpointEvent.Speed,
                    ShiftId = shiftId,
                    Timestamp = checkpointEvent.Timestamp,
                    TrackNumber = checkpointEvent.TrackNumber
                };

                EventModel model = new EventModel
                {
                    LocoNumber = checkpointEvent.TrainId,
                    Route = checkpointEvent.TrackNumber,
                    Type = checkpointEvent.Type,
                    Timestamp = checkpoint.Timestamp
                };

                _manager.checkpointEventRepository.CreatAsync(checkpoint);
               // await helper.InvokeEventToArchieveAsync(model, checkpoint.CheckPointNumber);
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