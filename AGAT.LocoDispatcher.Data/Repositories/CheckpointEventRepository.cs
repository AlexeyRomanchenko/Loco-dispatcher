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
        public CheckpointEventRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void CreatAsync(CheckpointEvent _event)
        {
                try
                {
                    _event.CreatedAt = DateTime.Now;
                    _context.CheckpointEvents.Add(_event);
                }
                catch (Exception)
                {
                    throw;
                }
        }

        public async Task<List<CheckpointEvent>> GetAsync()
        {
            return await _context.CheckpointEvents.ToListAsync();
        }
        public async Task<string> GetLastCheckpointByShiftIdAsync(int shiftId)
        {
            try
            {
                if (shiftId < 1)
                {
                    throw new ArgumentException("train id is not valid");
                }
                //System.Diagnostics.Debug.WriteLine(shiftId);
                // _context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                return await _context.CheckpointEvents.OrderByDescending(e => e.Timestamp)
                    .Where(e => e.ShiftId == shiftId).Select(e=>e.CheckPointNumber).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> GetLastCheckpointByLocoIdAsync(string locoId)
        {
            try
            {
               return await _context.Events.Where(e => e.CheckPointNumber != null && e.CheckPointNumber != "")
                            .Join(_context.LocoShiftEvents.Where(w => w.TrainNumber == locoId && w.EndShift == null),
                            ch => ch.ShiftId,
                            tr => tr.Id,
                            (ch, tr) =>
                            new
                            {
                                ch.CheckPointNumber,
                                ch.Timestamp,
                                ch.CreatedAt
                            })
                            .AsNoTracking()
                            .OrderByDescending(e => e.Timestamp).ThenByDescending(e => e.CreatedAt)
                            .Select(e => e.CheckPointNumber)
                            .FirstOrDefaultAsync();
            }
            catch (Exception)
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
                    return await _context.CheckpointEvents.AsNoTracking().OrderByDescending(e=>e.Timestamp).Take(count).ToListAsync();
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
