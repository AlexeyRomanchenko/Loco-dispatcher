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

        // GET: api/Emergency/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Emergency
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Emergency/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Emergency/5
        public void Delete(int id)
        {
        }
    }
}
