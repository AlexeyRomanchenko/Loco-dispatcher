using AGAT.LocoDispatcher.Common.Interfaces;
using AGAT.LocoDispatcher.Data.Events;
using AGAT.LocoDispatcher.Parser.Utils.Events;
using AGAT.LocoDispatcher.Parser.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AGAT.LocoDispatcher.Parser.Utils.Providers
{
    public class ShiftLocoProvider : IProvider
    {
        private LocoShiftHelper helper;
        public ShiftLocoProvider()
        {
            helper = new LocoShiftHelper();
        }
        public void Create(IEnumerable<IEvent> events)
        {
            try
            {
                foreach (var shiftEvent in events)
                {
                    ShiftLocomotiveEvent shiftLocomotive = (ShiftLocomotiveEvent)shiftEvent;
                    foreach (var train in shiftLocomotive.Trains)
                    {
                        string _trainNumber = LocoShiftHelper.TransformTrainNumber(train);
                        LocoShiftEvent locoShift = new LocoShiftEvent
                        {
                            TrainNumber = _trainNumber,
                            ESR = shiftLocomotive.ESR,
                        };
                        helper.AddLocoShiftAsync(locoShift, shiftLocomotive.Timestamp).GetAwaiter().GetResult();
                    }
                }

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