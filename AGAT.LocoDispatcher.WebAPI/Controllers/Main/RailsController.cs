using AGAT.LocoDispatcher.Common.Interfaces.Managers;
using AGAT.LocoDispatcher.Common.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Web.Http;

namespace AGAT.LocoDispatcher.WebAPI.Controllers.Main
{
    public class RailsController : ApiController
    {
        private IRailManager _manager;
        public RailsController(IRailManager manager)
        {
            _manager = manager;
        }
        // GET: api/Rails/5
        public IEnumerable<Rail> Get(int id)
        {
            if (id > 0)
            {
                try
                {
                    var rails = _manager.GetRailsByParkId(id);
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
