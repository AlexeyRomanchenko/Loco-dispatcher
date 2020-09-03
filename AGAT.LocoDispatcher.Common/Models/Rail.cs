using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Common.Models
{
    public class Rail
    {
        public int id { get; set; }
        public string railCode { get; set; }
        public int startX { get; set; }
        public int startY { get; set; }
        public bool Status { get; set; }
        public IEnumerable<Coords> Coords { get; set; }
        public int parkId { get; set; }
        public Carriage Carriage { get; set; }
        public RoutePlate Label { get; set; }
    }
}
