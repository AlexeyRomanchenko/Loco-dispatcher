using AGAT.LocoDispatcher.Common.Models.EventModels;
using AGAT.LocoDispatcher.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Business.Managers
{
    public class EmergencyManager
    {
        private BaseEventRepository repository;
        public EmergencyManager()
        {
            repository = new BaseEventRepository();
        }

        public async Task<List<EmergencyModel>> GetlastEmergencyAsync()
        {
            return await repository.GetLastEmergencyEventAsync();
        }
    }
}
