using AGAT.LocoDispatcher.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Data.Repositories
{
    public class CheckpointEventRepository
    {
        private DatabaseContext _context;
        public CheckpointEventRepository()
        {
            _context = new DatabaseContext();
        }
        public async Task CreatAsync(CheckpointEvent _event)
        {
            _event.CreatedAt = DateTime.Now;
            _context.CheckpointEvents.Add(_event);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CheckpointEvent>> GetAsync()
        {
            return await _context.CheckpointEvents.ToListAsync();
        }
        public async Task<string> GetLastCheckpointByTrainIdAsync(string trainId)
        {
            try
            {
                if (string.IsNullOrEmpty(trainId?.Trim()))
                {
                    throw new ArgumentException("train id is not valid");
                }
                string lastCheckpoint = await _context.CheckpointEvents
                    .OrderByDescending(e => e.Timestamp)
                    .Join(_context.LocoShiftEvents
                    .Where(e => e.TrainNumber == trainId),
                    events => events.ShiftId,
                    loco => loco.Id,
                    (checkpoint, loco) => checkpoint.CheckPointNumber)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
                return lastCheckpoint;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ICollection<CheckpointEvent>> GetLastNCheckpointsAsync(int count)
        {
            try
            {
                if (count > 0)
                {
                    return await _context.CheckpointEvents.AsNoTracking().OrderByDescending(e=>e.CreatedAt).Take(count).ToListAsync();
                }
                else
                {
                    throw new ArgumentException("count of requesting events is ot valid");
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
