using AGAT.LocoDispatcher.Business.Managers;
using AGAT.LocoDispatcher.Business.Models.RailModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AGAT.LocoDispatcher.WebAPI.Controllers.Main
{
    public class PointController : ApiController
    {
        private PointManager _manager;
        public PointController(PointManager manager)
        {
            _manager = manager;
        }
        // GET: api/Point
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                IEnumerable<Point> points = _manager.GetPointsByParkId(id);
                return Ok(points);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] List<Point> points)
        {
            try
            {
                foreach (var point in points)
                {
                    _manager.CreatePoints(id, point);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
