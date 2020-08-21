using AGAT.LocoDispatcher.Data.Events;
using AGAT.LocoDispatcher.Data.Models;
using System.Data.Entity;

namespace AGAT.LocoDispatcher.Data
{
    public class DatabaseContext : DbContext
    {
         public DatabaseContext() :
           base("name=DatabaseContext") { }

        public DbSet<MoveEventBase> Events { get; set; }
        public DbSet<StartMoveEvent> StartEvents { get; set; }
        public DbSet<StopMoveEvent> StopEvents { get; set; }
        public DbSet<LocoShiftEvent> LocoShiftEvents { get; set; }
        public DbSet<CheckpointEvent> CheckpointEvents { get; set; }
        public DbSet<EmergencyEvent> EmergencyEvents { get; set; }
    }
   
}
