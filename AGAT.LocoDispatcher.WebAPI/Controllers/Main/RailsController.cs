using AGAT.LocoDispatcher.Business.Managers;
using AGAT.LocoDispatcher.Business.Models.RailModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Web.Http;

namespace AGAT.LocoDispatcher.WebAPI.Controllers.Main
{
    public class RailsController : ApiController
    {
        private RailsManager manager;
        public RailsController()
        {
            manager = new RailsManager();
        }
        // GET: api/Rails/5
        public IEnumerable<Rail> Get(int id)
        {
            if (id > 0)
            {
                try
                {
                    var rails = manager.GetRailsByParkId(id);
                    return rails;
                }
                catch (EntityCommandExecutionException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                throw new ArgumentNullException("id is not valid");
            }
        }

        // PUT: api/Rails/5
        public void Put(int id, [FromBody]string value)
        {
        }

    }
}
