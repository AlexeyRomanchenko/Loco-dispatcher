using AGAT.LocoDispatcher.RailData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.RailData.Interfaces
{
    public interface IStationRepository
    {
        Task<IEnumerable<Station>> GetAsync();

    }
}
