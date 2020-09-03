using AGAT.LocoDispatcher.Common.Interfaces.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AGAT.LocoDispatcher.Common.Models.RailModels;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web;

namespace AGAT.LocoDispatcher.WebAPI.Controllers
{
    public class TrainController : ApiController
    {
        private ITrainManager _manager;
        public TrainController(ITrainManager manager)
        {
            _manager = manager;
        }
        // GET: api/Train/5
        public async Task<IHttpActionResult> Get(string id)
        {
            string code = HttpContext.Current.Request.QueryString["code"];
            if (string.IsNullOrEmpty(code?.Trim()))
            {
                return BadRequest("Код парка не определен");
            }
            var trains = await _manager.GetTrainsAsync(code, id);
            return Ok(trains);
        }
    }
}
