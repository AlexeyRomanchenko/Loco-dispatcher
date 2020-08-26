using AGAT.LocoDispatcher.AsusDb.Repositories;
using AGAT.LocoDispatcher.Business.Models.RouteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Business.Managers
{
    public class CarriageManager
    {
        private CarriageInfoRepository _repository;
        public CarriageManager()
        {
            _repository = new CarriageInfoRepository();
        }
        public IEnumerable<CarriageInfo> GetCarriageInfoByRouteId(int id)
        {
            try
            {
                var info = _repository.GetByRouteId(id);
                IEnumerable<CarriageInfo> result = Mapper.GetMapperInstance().Map<IEnumerable<CarriageInfo>>(info);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
