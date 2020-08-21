using AGAT.LocoDispatcher.Data.Models.Rails;
using AGAT.LocoDispatcher.Data.Repositories.RailRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Web.Http;

namespace AGAT.LocoDispatcher.WebAPI.Controllers.Main
{
    public class RailsController : ApiController
    {
        private RailsRepository repository;
        public RailsController()
        {
            repository = new RailsRepository();
        }
        // GET: api/Rails/5
        public IEnumerable<Rail> Get(int id)
        {
            if (id > 0)
            {
                try
                {
                    var rails = repository.GetById(id);
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
