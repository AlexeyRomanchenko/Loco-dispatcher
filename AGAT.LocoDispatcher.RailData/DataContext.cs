using AGAT.LocoDispatcher.RailData.Models;
using System.Data.Entity;

namespace AGAT.LocoDispatcher.RailData
{
        public class DataContext : DbContext
        {
            public DataContext() :
                base("DatabaseContext")
            { }

            public DbSet<Rail> Rails { get; set; }
            public DbSet<Coord> Coords{ get; set; }
            public DbSet<RoutePlate> RoutePlates { get; set; }
            public DbSet<Carriage> Carriages { get; set; }
            public DbSet<Point> Points { get; set; } 
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
            modelBuilder.Entity<Rail>().HasKey(e => e.Id);
            modelBuilder.Entity<Rail>().HasRequired(e => e.Carriage).WithRequiredPrincipal(e => e.Rail);
            modelBuilder.Entity<Rail>().HasRequired(e => e.RoutePlate).WithRequiredPrincipal(e => e.Rail);
            modelBuilder.Entity<Carriage>().HasKey(e=>e.Id);
                base.OnModelCreating(modelBuilder);
            }
    }
}
