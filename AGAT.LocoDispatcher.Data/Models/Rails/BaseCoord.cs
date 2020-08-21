using AGAT.LocoDispatcher.Common.Interfaces.Rails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Data.Models.Rails
{
    public class BaseCoord : ICoord
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
