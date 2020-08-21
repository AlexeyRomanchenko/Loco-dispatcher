using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Common.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T item);
        IEnumerable<T> GetById(int id);
    }
}
