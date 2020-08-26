using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AGAT.LocoDispatcher.WebAPI.Controllers.Main
{
    public class UserCheckController : ApiController
    {
        // GET: api/UserCheck
        public string Get()
        {
            return User.Identity.Name;
        }

        // GET: api/UserCheck/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UserCheck
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UserCheck/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserCheck/5
        public void Delete(int id)
        {
        }
    }
}
