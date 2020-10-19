using AGAT.LocoDispatcher.Data.Events;
using AGAT.LocoDispatcher.Parser.Utils.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AGAT.LocoDispatcher.Parser.Utils.Helpers
{
    public class LocoShiftHelper
    {
        private DataManager manager;
        public LocoShiftHelper()
        {
            manager = new DataManager();
        }
        public async Task AddLocoShiftAsync(LocoShiftEvent loco, int timestamp)
        {
            try
            {
                if (loco is null)
                {
                    throw new ArgumentNullException("Locomotive number is not valid");
                }
                LocoShiftEvent locoShift = await manager.shiftRepository.GetActiveByNameAsync(loco.TrainNumber);
                if (locoShift is null)
                {
                    LocoShiftEvent shiftEvent = new LocoShiftEvent
                    {
                        CreatedAt = DateTime.Now,
                        ESR = loco.ESR,
                        IsValid = true,
                        StartShift = ConvertHelper.TimestampToDateTime(timestamp),
                        TrainNumber = loco.TrainNumber
                    };
                    await manager.shiftRepository.CreateAsync(shiftEvent);
                }
                else if (!locoShift.IsValid)
                {
                    await manager.shiftRepository.UpdateShiftStartAsync(locoShift, ConvertHelper.TimestampToDateTime(timestamp), loco.ESR);
                }
                else
                {
                    await manager.shiftRepository.UpdateShiftEndAsync(locoShift, ConvertHelper.TimestampToDateTime(timestamp));
                    LocoShiftEvent newShiftEvent = new LocoShiftEvent
                    {
                        CreatedAt = DateTime.Now,
                        ESR = locoShift.ESR,
                        IsValid = true,
                        StartShift = ConvertHelper.TimestampToDateTime(timestamp),
                        TrainNumber = locoShift.TrainNumber
                    };
                    await manager.shiftRepository.CreateAsync(newShiftEvent);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static string TransformTrainNumber(string trainNumber)
        {
            if (string.IsNullOrEmpty(trainNumber?.Trim()))
            {
                throw new ArgumentException("train number is not valid");
            }
            int counter = 4 - trainNumber.Trim().Length;
            for (int i = 0; i < counter; i++)
            {
                trainNumber = $"0{trainNumber.Trim()}";
            };
            return trainNumber;
        }
    }
}