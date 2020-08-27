using AGAT.LocoDispatcher.Business.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AGAT.LocoDispatcher.WebAPI.Controllers.Main
{
    public class CarriageInfoController : ApiController
    {
        private CarriageManager _manager;
        public CarriageInfoController()
        {
            _manager = new CarriageManager();
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var carInformation = _manager.GetCarriageInfoByRouteId(id);
                return Ok(carInformation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
