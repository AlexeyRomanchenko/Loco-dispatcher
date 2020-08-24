using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Business.Models.RailModels
{
    public class Point
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Angle { get; set; }
        public Coords Coord { get; set; }
    }
}
