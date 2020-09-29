using AGAT.LocoDispatcher.Business.Managers;
using AGAT.LocoDispatcher.Common.Models.EventModels;
using AGAT.LocoDispatcher.Data.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AGAT.LocoDispatcher.WebAPI.Controllers.Main
{
    public class EmergencyMessageController : ApiController
    {
        private EmergencyManager manager;
        public EmergencyMessageController()
        {
            manager = new EmergencyManager();
        }
        // GET: api/Emergency
        public async Task<List<EmergencyModel>> Get()
        {
            return await manager.GetlastEmergencyAsync();
        }
    }
}
