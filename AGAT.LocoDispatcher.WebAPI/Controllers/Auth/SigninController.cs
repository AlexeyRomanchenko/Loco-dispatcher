using AGAT.LocoDispatcher.AuthData.Managers;
using AGAT.LocoDispatcher.AuthData.Models;
using AGAT.LocoDispatcher.WebAPI.Filters;
using AGAT.LocoDispatcher.WebAPI.Models.ViewModels;
using AGAT.LocoDispatcher.WebAPI.Utils.Auth;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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
        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>();
            }
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
        public async Task<HttpResponseMessage> Post([FromBody] UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Username == "admin" && model.Password == "admin0505")
                {
                    User user = new User
                    {
                        UserName = model.Username
                    };
                    IdentityResult result = await UserManager.CreateAsync(user, model.Password);

                    return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, new 
                    {
                        username =  model.Username,
                        token = TokenManager.GenerateToken(model.Username)
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
