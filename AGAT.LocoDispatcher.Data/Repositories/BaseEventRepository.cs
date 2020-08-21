
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
    }
}
