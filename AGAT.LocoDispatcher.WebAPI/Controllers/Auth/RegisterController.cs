using AGAT.LocoDispatcher.AuthDB.Models;
using AGAT.LocoDispatcher.AuthDB.Repositories;
using AGAT.LocoDispatcher.AuthDB.Utils;
using AGAT.LocoDispatcher.WebAPI.Filters;
using AGAT.LocoDispatcher.WebAPI.Handlers;
using AGAT.LocoDispatcher.WebAPI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AGAT.LocoDispatcher.WebAPI.Controllers.Auth
{
    public class RegisterController : ApiController
    {
        private UserRepository repository;
        public RegisterController()
        {
            repository = new UserRepository();
        }
        // POST: api/Register
        [JwtAuthenticationFilter]
        public async Task<HttpResponseMessage> Post(RegisterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User user = new User
                    {
                        Username = model.Username,
                        Password = HashProducer.HashPassword(model.Password),
                        RoleId = model.RoleId,
                        StationId = 1
                    };
                    repository.Create(user);
                    await repository.SaveAsync();
                    var newUser = await repository.GetByIdAsync(user.Id);
                    return Request.CreateResponse(HttpStatusCode.OK, newUser);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorHandler.HandleErrors(ModelState));
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
           
        }
    }
}
