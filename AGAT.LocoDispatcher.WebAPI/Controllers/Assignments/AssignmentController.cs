using AGAT.LocoDispatcher.Business.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AGAT.LocoDispatcher.WebAPI.Controllers.Assignments
{
    public class AssignmentController : ApiController
    {
        private AssignmentManager manager;
        public AssignmentController()
        {
            manager = new AssignmentManager();
        }
        [HttpGet]
        public async Task<IEnumerable<Business.Models.Assignment>> Get()
        {
            return await manager.GetAsync();
        }
        [HttpGet]
        public async Task<IEnumerable<Business.Models.Assignment>> Get(string id)
        {
            return await manager.GetByCodeAsync(id);
        }
    }
}
