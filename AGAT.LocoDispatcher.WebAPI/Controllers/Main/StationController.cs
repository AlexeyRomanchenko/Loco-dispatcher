using AGAT.LocoDispatcher.RailData;
using AGAT.LocoDispatcher.RailData.Interfaces;
using AGAT.LocoDispatcher.RailData.Models;
using AGAT.LocoDispatcher.RailData.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace AGAT.LocoDispatcher.WebAPI.Controllers.Main
{
    public class StationController : ApiController
    {
        private IStationRepository stationRepository;
        public StationController()
        {
            DataContext context = new DataContext();
            stationRepository = new StationRepository(context);
        }
        // GET: api/Station
        public async Task<IEnumerable<Station>> Get()
        {
            return await stationRepository.GetAsync();
        }

        // GET: api/Station/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Station
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Station/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Station/5
        public void Delete(int id)
        {
        }
    }
}
