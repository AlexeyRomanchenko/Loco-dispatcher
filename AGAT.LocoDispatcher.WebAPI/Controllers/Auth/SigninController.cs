using AGAT.LocoDispatcher.AuthDB.Models;
using AGAT.LocoDispatcher.AuthDB.Repositories;
using AGAT.LocoDispatcher.AuthDB.Utils;
using AGAT.LocoDispatcher.WebAPI.Filters;
using AGAT.LocoDispatcher.WebAPI.Handlers;
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
        private HashProducer hasher;
        public SigninController()
        {
            repository = new UserRepository();
            hasher = new HashProducer();
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
        [HttpPost]
        public async Task<HttpResponseMessage> Post(UserViewModel model)
        {
            try
            {
                if (model is null)
                {
                    throw new ArgumentNullException("Данные не валидны");
                }
                if (ModelState.IsValid)
                {
                    User user = new User
                    {
                        Username = model.Username
                    };
                    User loggedUser = await repository.GetAsync(user);
                    if (loggedUser != null)
                    {
                        var isAuthenticated = hasher.Compare(model.Password.Trim(), loggedUser.Password);
                        if (isAuthenticated)
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
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.Unauthorized);
                    }
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorHandler.HandleErrors(ModelState));
            }
            catch (Exception ex)
            {
                string[] errorMessage = new[] { ex.Message }; 
                return Request.CreateResponse(HttpStatusCode.BadRequest, errorMessage);
            }
           
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
