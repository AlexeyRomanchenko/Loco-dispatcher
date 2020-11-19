using AGAT.locoDispatcher.ArchiveDB.Extensions;
using AGAT.LocoDispatcher.Common.Interfaces;
using AGAT.LocoDispatcher.Data.Events;
using AGAT.LocoDispatcher.Parser.Utils.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Parser.Utils.Helpers
{
    public class EventHelper
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
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
        public async Task InvokeEventToArchieveAsync(IMoveEvent model, string pointCode, string trackerId = "")
        {
            try
            {
                if (string.IsNullOrEmpty(pointCode?.Trim()))
                {
                    // if we dont have a checkpoint number - we are trying to find last known point by this loco number
                    pointCode = await manager.checkpointEventRepository.GetLastCheckpointByLocoIdAsync(model.LocoNumber);
                }
                logger.Info($"Start SP invoking with pointCode {pointCode}, event {model.Type}");
                if (!string.IsNullOrEmpty(pointCode?.Trim()))
                {
                    IStationInfo stationInfo = await manager.pointRepository.GetStationInfoByPointCode(pointCode);
                    model.Park = stationInfo?.Park;
                    model.StationCode = stationInfo?.StationCode;
                    model.Route = model.Route.Length > 0 ?  model.Route :  stationInfo?.Route; 
                    model.EventDateTime = ConvertHelper.TimestampToDateTime(model.Timestamp);
                }
                logger.Info($"SP invoking with park {model.Park}, station code {model.StationCode},route {model.Route} , event dateTime {model.EventDateTime} ");
                // Если крайняя точка, то меняем событие для передачи в процедуру
                pointCode.CheckEdgeCheckpoint(model);
                // Здесь вызываем процедуру для передачи в задания
                manager.trackRepository.InvokeEventAsync(model);
                logger.Info($"SP was invoked successfully");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

       

    }
}