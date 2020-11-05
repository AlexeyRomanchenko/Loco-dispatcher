using AGAT.LocoDispatcher.Business.Models;
using AGAT.LocoDispatcher.Business.Models.RailModels;
using AGAT.LocoDispatcher.Common.Models.EventModels;
using AGAT.LocoDispatcher.Data;
using AGAT.LocoDispatcher.Data.Events;
using AGAT.LocoDispatcher.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Business.Managers
{
    public class LocoManager
    {
        private ShiftRepository repository;
        private BaseEventRepository baseEventRepository;
        private PointManager pointManager;
        private CheckpointEventRepository checkpointRepository;
        public LocoManager()
        {
            DatabaseContext context = new DatabaseContext();
            repository = new ShiftRepository();
            baseEventRepository = new BaseEventRepository();
            pointManager = new PointManager();
            checkpointRepository = new CheckpointEventRepository(context);
        }

        public async Task<IEnumerable<LocomotiveViewModel>> GetActiveByStationAsync(string station, int parkId)
        {
            try
            {
                List<LocomotiveViewModel> locomotives = new List<LocomotiveViewModel>();
                IEnumerable<LocoShiftEvent> locoShifts = await repository.GetActiveByStationAsync(station);
                foreach (var loco in locoShifts)
                {

                    int? direction = await repository.GetLocomotiveDirectionParityByShiftAsync(loco.Id);
                    MoveEventBase _event = await GetLastEventAsync(loco.Id);
                   
                    if (!string.IsNullOrEmpty(_event?.CheckPointNumber.Trim()))
                    {
                        LocomotiveViewModel locomotive = new LocomotiveViewModel
                        {
                            Id = loco.Id,
                            ESR = loco.ESR,
                            TrainNumber = loco.TrainNumber,
                            PointId = _event.CheckPointNumber,
                            Direction = direction,
                        };
                        locomotive.IsStopped = _event?.Type == "stop_move" ? true : false;
                        //_event.CheckPointNumber
                        Point point = await pointManager.GetPointByCode(_event.CheckPointNumber, parkId);
                        if (point != null)
                        {
                            locomotive.Coords = point.Coord;
                            locomotive.Angle = point.Angle;
                        }
                        locomotives.Add(locomotive);
                    }
                    else
                    {
                        string lastCheckpoint = await checkpointRepository.GetLastCheckpointByShiftIdAsync(loco.Id);
                       
                        LocomotiveViewModel locomotive = new LocomotiveViewModel
                        {
                            Id = loco.Id,
                            ESR = loco.ESR,
                            TrainNumber = loco.TrainNumber,
                            Angle = 0,
                            Coords = null,
                            Direction = direction

                        };
                        if (!string.IsNullOrEmpty(lastCheckpoint?.Trim()))
                        {
                            Point point = await pointManager.GetPointByCode(lastCheckpoint, parkId);
                            if (point != null)
                            {
                                locomotive.Coords = point.Coord;
                                locomotive.Angle = point.Angle;
                            }
                        }

                        locomotive.IsStopped = _event?.Type == "stop_move" ? true : false;
                        locomotives.Add(locomotive);
                    }

                }

                return locomotives;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private async Task<MoveEventBase> GetLastEventAsync(int locoShiftId)
        {
            return await baseEventRepository.GetLastEventByShiftIdAsync(locoShiftId);
        }

        public async Task<IEnumerable<BasicEventModel>> GetLastNEventsAsync(int amount)
        {
            var lastEvents = await baseEventRepository.GetLastNEventsAsync(amount);
            List<BasicEventModel> _lastEvents = new List<BasicEventModel>();
            foreach (var _event in lastEvents)
            {
                BasicEventModel basicEvent = new BasicEventModel
                {
                 Type = _event.Type,
                 CheckPointNumber = _event.CheckPointNumber,
                 CreatedAt = _event.CreatedAt,
                 Message = _event.Message,
                 Timestamp = _event.Timestamp,
                 TrackNumber = _event.TrackNumber
                };
                _lastEvents.Add(basicEvent);
            }
            return _lastEvents;
        }

    }
}
