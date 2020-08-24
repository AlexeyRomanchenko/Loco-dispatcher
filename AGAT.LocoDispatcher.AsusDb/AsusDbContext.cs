using AGAT.LocoDispatcher.AsusDb.Models;
using System.Data.Entity;
namespace AGAT.LocoDispatcher.AsusDb
{
    public class AsusDbContext : DbContext
    {
        public AsusDbContext() :
          base("name=DatabaseContext")
        { }

        public DbSet<Route> Routes { get; set; }
        public DbSet<CarriageInfo> CarriageInfos { get; set; }
        public DbSet<StationPark> Parks { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<StationPark> StationParks { get; set; }
    }
}
