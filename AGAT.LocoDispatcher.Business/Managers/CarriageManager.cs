using AGAT.LocoDispatcher.AsusDb.Models;
using AGAT.LocoDispatcher.AsusDb.Repositories;
using AGAT.LocoDispatcher.Business.Models.RouteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarriageInfo = AGAT.LocoDispatcher.Business.Models.RouteModels.CarriageInfo;

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
                IList<vagon> infoItems = _repository.GetByRouteId(id);
                List<AsusDb.Models.CarriageInfo> carriageInfos = new List<AsusDb.Models.CarriageInfo>(); 
                foreach (var item in infoItems)
                {
                    AsusDb.Models.CarriageInfo carriageInfo = new AsusDb.Models.CarriageInfo
                    {
                    Id = item.in_vgn,
                    RouteId = item.way_id,
                    OwnerCode = item.cod_sbs,
                    Order = item.ord_num ,
                    LoadWeight = item.ves_gruz,
                    DestinationCode = item.st_destn,
                    Description = item.prim
                    };
                    carriageInfos.Add(carriageInfo);
                }

                IEnumerable<CarriageInfo> result = Mapper.GetMapperInstance().Map<IEnumerable<CarriageInfo>>(carriageInfos);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
