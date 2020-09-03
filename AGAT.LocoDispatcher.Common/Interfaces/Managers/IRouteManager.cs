

using AGAT.LocoDispatcher.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Common.Interfaces.Managers
{
    public interface IRouteManager
    {
        Task<IEnumerable<Route>> GetRoutesByParkCodeAsync(string station, string code);
    }
}
