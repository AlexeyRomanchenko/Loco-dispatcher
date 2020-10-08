using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.AuthDB.Interfaces
{
    interface IComparator
    {
        bool Compare(string income, string hash);
    }
}
