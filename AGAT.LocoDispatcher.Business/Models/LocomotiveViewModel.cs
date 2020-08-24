using AGAT.LocoDispatcher.Business.Models.RailModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Business.Models
{
    public class LocomotiveViewModel : Locomotive
    {
        public string PointId { get; set; }
        public Coords Coords { get; set; }
        public int Angle { get; set; }
    }
}
