using AGAT.LocoDispatcher.Business.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AGAT.LocoDispatcher.WebAPI.Controllers.Main
{
    public class FailedEventController : ApiController
    {
        private EventManager eventManager;
        public FailedEventController()
        {
            eventManager = new EventManager();
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                var invalidEvents = await eventManager.GetInvalidNCheckpointEvents(id);
                return Ok(invalidEvents);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
