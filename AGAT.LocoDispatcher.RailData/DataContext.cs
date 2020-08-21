using AGAT.LocoDispatcher.Data.Models.Rails;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.RailData
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DatabaseContext")
        { }

        public DbSet<Rail> Rails { get; set; }
        public DbSet<Carriage> Carriages { get; set; }
        public DbSet<RoutePlate> RoutePlates { get; set; }
        public DbSet<Park> Parks { get; set; }
    }
}
