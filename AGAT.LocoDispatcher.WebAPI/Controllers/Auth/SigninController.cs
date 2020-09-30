using AGAT.LocoDispatcher.WebAPI.Filters;
using AGAT.LocoDispatcher.WebAPI.Models.ViewModels;
using AGAT.LocoDispatcher.WebAPI.Utils.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AGAT.LocoDispatcher.WebAPI.Controllers.Auth
{
    public class SigninController : ApiController
    {
        // GET: api/Signin
        [JwtAuthenticationFilter]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Signin/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Signin
        public HttpResponseMessage Post([FromBody] UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Username == "admin" && model.Password == "admin")
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new 
                    {
                        username =  model.Username,
                        token = TokenManager.GenerateToken(model.Username)
                    });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized);
                }               
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Model is not valid");
        }

        // PUT: api/Signin/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Signin/5
        public void Delete(int id)
        {
        }
    }
}
