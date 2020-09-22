
using AGAT.LocoDispatcher.Common.Models.EventModels;
using AGAT.LocoDispatcher.Data.Events;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Data.Repositories
{
    public class BaseEventRepository
    {
        public async Task<MoveEventBase> GetLastEventByShiftIdAsync(int shiftId)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                MoveEventBase lastEvent = await context.Events
                    .Where(e => e.ShiftId == shiftId && e.CheckPointNumber != null)
                    .OrderByDescending(e => e.Timestamp).FirstOrDefaultAsync();
                return lastEvent;
            }
        }

        public async Task<List<EmergencyModel>> GetLastEmergencyEventAsync()
        {
            List<EmergencyModel> emergencyEvents = new List<EmergencyModel>();
            using (DatabaseContext context = new DatabaseContext())
            {
                List<int> activeShiftIds = await context.LocoShiftEvents.Where(e => e.EndShift == null).Select(e=>e.Id).ToListAsync();
                foreach (var shiftId in activeShiftIds)
                {
                   var lastEvent = await context.Events.AsNoTracking()
                    .Where(e => e.ShiftId == shiftId)
                    .Join(context.LocoShiftEvents, ev => ev.ShiftId, shift => shift.Id, (events, shifts) =>
                    new EmergencyModel
                    {
                        Timestamp = events.Timestamp,
                        Type = events.Type,
                        TrainNumber = shifts.TrainNumber
                    }).OrderByDescending(e => e.Timestamp).FirstOrDefaultAsync();
                    if (lastEvent?.Type == "emergency")
                    {
                        emergencyEvents.Add(lastEvent);
                    }
                    
                }
                return emergencyEvents;
            }
        }
    }
}
