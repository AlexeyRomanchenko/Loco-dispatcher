using AGAT.LocoDispatcher.Business.Managers;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AGAT.LocoDispatcher.WebAPI.Controllers.Main
{
    public class LastEventsController : ApiController
    {
        private LocoManager _locoManager;
        public LastEventsController()
        {
            _locoManager = new LocoManager();
        }
        // GET: api/LastEvents
        [HttpGet]
        public async Task<HttpResponseMessage> Get()
        {
            var lastEvents = await _locoManager.GetLastNEventsAsync(5);
            return Request.CreateResponse(HttpStatusCode.OK, lastEvents);
        }
    }
}
