using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.RailData.Models
{
    public class Rail
    {
        public Rail()
        {
            this.Coords = new HashSet<Coord>();
            //Points = new List<Point>();
        }
        [Key]
        public int Id { get; set; }
        public string RailCode { get; set; }
        public ICollection<Coord> Coords { get; set; }
        public int ParkId { get; set; }
        public Park Park { get; set; }
        public Carriage Carriage { get; set; }
        public RoutePlate RoutePlate { get; set; }
        //public ICollection<Point> Points { get; set; }
    }
}
