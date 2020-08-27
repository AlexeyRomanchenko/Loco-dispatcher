using AGAT.LocoDispatcher.Data.Events;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Data.Repositories
{
    public class ShiftRepository
    {
        private DatabaseContext context;
        public ShiftRepository()
        {
            context = new DatabaseContext();
        }
        public async Task<IEnumerable<LocoShiftEvent>> GetActiveByStationAsync(string station)
        {
            try
            {
                var shifts =  await context.LocoShiftEvents.Where(e => e.EndShift == null && e.ESR == station).ToListAsync();
                return shifts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<LocoShiftEvent> GetActiveByNameAsync(string locoNumber)
        {
            try
            {
                return await context.LocoShiftEvents.Where(e => e.EndShift == null && e.TrainNumber == locoNumber).SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task CreateAsync(LocoShiftEvent locoShift)
        {
            try
            {
                context.LocoShiftEvents.Add(locoShift);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task UpdateShiftEndAsync(LocoShiftEvent _event, DateTime endShift)
        {
            try
            {
                if (_event is null)
                {
                    throw new ArgumentNullException("input parameters are not valid");
                }

                _event.EndShift = endShift;
                _event.IsValid = true;
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task UpdateShiftStartAsync(LocoShiftEvent _event, DateTime startShift, string esr)
        {
            try
            {
                if (_event is null)
                {
                    throw new ArgumentNullException("input parameters are not valid");
                }
                _event.ESR = esr;
                _event.StartShift = startShift;
                _event.IsValid = true;
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
