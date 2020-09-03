using AGAT.LocoDispatcher.Common.Models.RailModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Common.Interfaces.Managers
{
    public interface ITrainManager
    {
        Task<IEnumerable<Train>> GetTrainsAsync(string parkCode, string code);
    }
}
