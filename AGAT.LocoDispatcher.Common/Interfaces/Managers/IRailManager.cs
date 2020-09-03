using AGAT.LocoDispatcher.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Common.Interfaces.Managers
{
    public interface IRailManager
    {
        IEnumerable<Rail> GetRailsByParkId(int id);
    }
}
