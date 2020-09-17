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
                        ESR = "",
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
            await manager.pointRepository.GetStationInfoByPointCode(pointCode);
            await manager.trackRepository.InvokeEventAsync(model);
        }
    }
}