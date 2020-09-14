using AGAT.LocoDispatcher.Business.Models;
using AGAT.LocoDispatcher.Business.Models.RailModels;
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
        public LocoManager()
        {
            repository = new ShiftRepository();
            baseEventRepository = new BaseEventRepository();
            pointManager = new PointManager();
        }

        public async Task<IEnumerable<LocomotiveViewModel>> GetActiveByStationAsync(string station, int parkId)
        {
            try
            {
                List<LocomotiveViewModel> locomotives = new List<LocomotiveViewModel>();
                IEnumerable<LocoShiftEvent> locoShifts = await repository.GetActiveByStationAsync(station);
                foreach (var loco in locoShifts)
                {
                    MoveEventBase _event = await GetLastEventAsync(loco.Id);
                    if (!string.IsNullOrEmpty(_event?.CheckPointNumber.Trim()))
                    {
                        LocomotiveViewModel locomotive = new LocomotiveViewModel
                        {
                            Id = loco.Id,
                            ESR = loco.ESR,
                            TrainNumber = loco.TrainNumber,
                            PointId = _event.CheckPointNumber
                        };
                        //_event.CheckPointNumber
                        Point point = await pointManager.GetPointByCode(_event.CheckPointNumber, parkId);
                        if (point != null)
                        {
                            locomotive.Coords = point.Coord;
                            locomotive.Angle = point.Angle;
                            locomotives.Add(locomotive);
                        }
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

    }
}
