using AGAT.LocoDispatcher.Common.Interfaces;
using AGAT.LocoDispatcher.Data.Events;
using AGAT.LocoDispatcher.Parser.Utils.Managers;
using System;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Parser.Utils.Helpers
{
    public class EventHelper
    {
        private DataManager manager;
        public EventHelper()
        {
            manager = new DataManager();
        }

        public async Task<int> GetLocoShiftIdByLocoNumber(string locoNumber)
        {
            try
            {
                LocoShiftEvent shiftEvent = await manager.shiftRepository.GetActiveByNameAsync(locoNumber);
                if (shiftEvent is null)
                {
                    LocoShiftEvent newShiftEvent = new LocoShiftEvent
                    {
                        CreatedAt = DateTime.Now,
                        ESR = "14043",
                        IsValid = false,
                        StartShift = DateTime.Now,
                        TrainNumber = locoNumber
                    };
                    await manager.shiftRepository.CreateAsync(newShiftEvent);
                    return await GetLocoShiftIdByLocoNumber(locoNumber);
                }
                else
                {
                    return shiftEvent.Id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task InvokeEventToArchieveAsync(IMoveEvent model, string pointCode)
        {
            try
            {
                if (string.IsNullOrEmpty(pointCode?.Trim()))
                {
                    pointCode = await manager.checkpointEventRepository.GetLastCheckpointByTrainIdAsync(model.LocoNumber);
                }
                IStationInfo stationInfo = await manager.pointRepository.GetStationInfoByPointCode(pointCode);
                model.Park = stationInfo?.Park;
                model.StationCode = stationInfo?.StationCode;
                model.EventDateTime = ConvertHelper.TimestampToDateTime(model.Timestamp);
                if (string.IsNullOrEmpty(model.Park?.Trim()))
                {
                    return;
                }
                manager.trackRepository.InvokeEventAsync(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}