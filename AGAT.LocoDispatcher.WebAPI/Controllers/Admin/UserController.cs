﻿using AGAT.LocoDispatcher.AuthDB.Models;
using AGAT.LocoDispatcher.AuthDB.Repositories;
using AGAT.LocoDispatcher.WebAPI.Filters;
using AGAT.LocoDispatcher.WebAPI.Handlers;
using AGAT.LocoDispatcher.WebAPI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace AGAT.LocoDispatcher.WebAPI.Controllers.Admin
{
    public class UserController : ApiController
    {
        private UserRepository userRepository;
        public UserController()
        {
            userRepository = new UserRepository();
        }
        // GET: api/User
        [JwtAuthenticationFilter]
        public async Task<HttpResponseMessage> Get()
        {
            try
            {
                var users = await userRepository.GetAllAsync();
                return Request.CreateResponse(HttpStatusCode.OK,users);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [JwtAuthenticationFilter]
        [Route("user/role")]
        public string GetRole() 
        {
            var role = ((ClaimsIdentity)User.Identity).Claims
        .Where(c => c.Type == ClaimTypes.Role)
        .Select(c => c.Value).FirstOrDefault();
            return role;
        }

        [HttpPut]
        public HttpResponseMessage Put([FromBody] EditViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, model);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorHandler.HandleErrors(ModelState));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    var userToDelete = await userRepository.GetByIdAsync(id);
                    if (userToDelete is null)
                    {
                        throw new ArgumentException("User was not found");
                    }
                    userRepository.Remove(userToDelete);
                    await userRepository.SaveAsync();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    throw new ArgumentNullException("Id is not valid");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
           
        }
    }
}