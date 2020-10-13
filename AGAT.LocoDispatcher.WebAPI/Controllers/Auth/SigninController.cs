using AGAT.LocoDispatcher.AuthDB.Models;
using AGAT.LocoDispatcher.AuthDB.Repositories;
using AGAT.LocoDispatcher.WebAPI.Filters;
using AGAT.LocoDispatcher.WebAPI.Models.ViewModels;
using AGAT.LocoDispatcher.WebAPI.Utils.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AGAT.LocoDispatcher.WebAPI.Controllers.Auth
{
    public class SigninController : ApiController
    {
        private UserRepository repository;
        public SigninController()
        {
            repository = new UserRepository();
        }
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
        public async Task<HttpResponseMessage> Post(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Username = model.Username,
                    Password = model.Password
                };
                User loggedUser = await repository.GetAsync(user);
                if (loggedUser != null)
                {
                    return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        username = loggedUser.Username,
                        token = TokenManager.GenerateToken(loggedUser.Username, loggedUser.Role?.Name)
                    }));
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
