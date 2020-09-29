using AGAT.LocoDispatcher.Data.Models;
using AGAT.LocoDispatcher.Data.Repositories;
using AGAT.LocoDispatcher.RailData.Models;
using AGAT.LocoDispatcher.RailData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Business.Managers
{
    public class EventManager
    {
        private CheckpointEventRepository eventRepository;
        private PointRepository pointRepository;
        public EventManager()
        {
            eventRepository = new CheckpointEventRepository();
            pointRepository = new PointRepository();
        }

        public async Task<IEnumerable<CheckpointEvent>> GetInvalidNCheckpointEvents(int count)
        {
            ICollection<CheckpointEvent> invalidEvents = new List<CheckpointEvent>();
            IEnumerable<CheckpointEvent> checkpoints = await eventRepository.GetLastNCheckpointsAsync(count);
            foreach (var checkpoint in checkpoints)
            {
                Point point = await pointRepository.GetPointByCodeAsync(checkpoint.CheckPointNumber);
                if (point is null)
                {
                    invalidEvents.Add(checkpoint);
                }
            }
            return invalidEvents;
        }

    }
}
