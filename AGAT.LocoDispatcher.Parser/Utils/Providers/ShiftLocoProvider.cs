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
        public async Task Create(IEvent _event)
        {
            try
            {
                ShiftLocomotiveEvent shiftLocomotive = (ShiftLocomotiveEvent)_event;
                foreach (var train in shiftLocomotive.Trains)
                {
                    LocoShiftEvent locoShift = new LocoShiftEvent
                    {
                        TrainNumber = train,
                        ESR = shiftLocomotive.ESR,
                    };
                    await helper.AddLocoShiftAsync(locoShift, shiftLocomotive.Timestamp);
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