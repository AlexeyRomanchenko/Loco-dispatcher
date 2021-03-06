﻿using AGAT.LocoDispatcher.Business.Managers;
using AGAT.LocoDispatcher.Business.Models.RouteModels;
using AGAT.LocoDispatcher.Common.Interfaces.Managers;
using AGAT.LocoDispatcher.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AGAT.LocoDispatcher.WebAPI.Controllers.Main
{
    public class RoutesController : ApiController
    {
        private IRouteManager _routesManager;
        public RoutesController(IRouteManager manager)
        {
            _routesManager = manager;
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                string code = HttpContext.Current.Request.QueryString["code"];
                if (id > 0)//!string.IsNullOrEmpty(station?.Trim()) && !string.IsNullOrEmpty(code?.Trim())
                {
                    IEnumerable<Route> routes = await _routesManager.GetRoutesByParkCodeAsync(id.ToString(), code);
                    return Ok(routes);//routes
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
    }
}
