using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Common.Interfaces.Rails
{
    public interface IRail
    {
        int Id { get; set; }
        IEnumerable<ICoord> Coords { get; set; }
    }
}
