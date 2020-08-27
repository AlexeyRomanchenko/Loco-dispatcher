using AGAT.LocoDispatcher.Business.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AGAT.LocoDispatcher.WebAPI.Controllers.Main
{
    public class LocoController : ApiController
    {
        private LocoManager _locoManager;
        public LocoController()
        {
            _locoManager = new LocoManager();
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get(string id)
        {
            try
            {
                string parkId = HttpContext.Current.Request.QueryString["parkId"];
                int _parkId = Convert.ToInt32(parkId);
                var locomotives = await _locoManager.GetActiveByStationAsync(id, _parkId);
                return Ok(locomotives);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
