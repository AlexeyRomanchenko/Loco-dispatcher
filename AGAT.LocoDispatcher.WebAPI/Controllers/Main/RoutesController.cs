using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace AGAT.LocoDispatcher.WebAPI.Controllers.Main
{
    public class RoutesController : ApiController
    {
        // GET: api/Routes
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Routes/5
        public IHttpActionResult Get(string station)
        {
            try
            {
                string code = HttpContext.Current.Request.QueryString["code"];
                if (!string.IsNullOrEmpty(station?.Trim()) && !string.IsNullOrEmpty(code?.Trim()))
                {
                   // IEnumerable<Route> routes = await _routesManager.GetRoutesByParkCodeAsync(station, code);
                    return Ok();//routes
                }
                else
                {
                    throw new ArgumentNullException("Нераспознан код станции или парка");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Routes
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Routes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Routes/5
        public void Delete(int id)
        {
        }
    }
}
