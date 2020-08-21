using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Common.Interfaces
{
    public interface IProvider
    {
        Task Create(IEvent _event);
    }
}
