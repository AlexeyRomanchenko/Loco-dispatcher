using AGAT.LocoDispatcher.AuthDB.Repositories;
using AGAT.LocoDispatcher.WebAPI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace AGAT.LocoDispatcher.WebAPI.Controllers
{
    public class RoleController : ApiController
    {
        private RoleRepository repository;
        public RoleController()
        {
            repository = new RoleRepository();
        }
        // GET: api/Role
        [JwtAuthenticationFilter]
        public async Task<HttpResponseMessage> Get()
        {
            try
            {
                var roles = await repository.GetAsync();
                return Request.CreateResponse(HttpStatusCode.OK, roles);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,ex.Message);
            }
        }

        // GET: api/Role/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Role
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Role/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Role/5
        public void Delete(int id)
        {
        }
    }
}
