using AGAT.LocoDispatcher.Business.Models.RailModels;
using AGAT.LocoDispatcher.Data.Repositories.RailRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Business.Managers
{
    public class RailsManager
    {
        RailsRepository _repository;
        public RailsManager()
        {
            _repository = new RailsRepository();
        }
        public IEnumerable<Rail> GetRailsByParkId(int id)
        {
            try
            {
                IEnumerable<RailData.Models.Rail> _rails = _repository.GetById(id);
                var rails = Mapper.GetMapperInstance().Map<IEnumerable<Rail>>(_rails);
                return rails;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void CreateRail(int parkId, Rail rail)
        {
            RailData.Models.Rail railDbo = Mapper.GetMapperInstance().Map<RailData.Models.Rail>(rail);
            railDbo.ParkId = parkId;
            _repository.Create(railDbo);
        }
    }
}
