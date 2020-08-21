using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AGAT.LocoDispatcher.Data.Models.Rails
{
    public class Rail
    {
        [Key]
        public int Id { get; set; }
        public string RailCode { get; set; }
        public ICollection<Coord> Coords { get; set; }
        public int ParkId { get; set; }
        public Park Park { get; set; }
        public Carriage Carriage { get; set; }
        public RoutePlate RoutePlate { get; set; }
    }
}
