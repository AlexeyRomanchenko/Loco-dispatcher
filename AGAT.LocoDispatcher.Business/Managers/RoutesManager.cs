using AGAT.LocoDispatcher.AsusDb.Models;
using AGAT.LocoDispatcher.AsusDb.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Business.Managers
{
    public class RoutesManager
    {
        private RouteRepository _routeRepository;
        private StationParkRepository _parkRepository;
        public RoutesManager()
        {
            _routeRepository = new RouteRepository();
            _parkRepository = new StationParkRepository();
        }

        public async Task<IEnumerable<Models.RouteModels.Route>> GetRoutesByParkCodeAsync(string station, string code)
        {
            try
            {
                park park = await _parkRepository.GetParkByStationAndCodeAsync(station, code);
                StationPark stationPark = new StationPark
                {
                    Id = park.prk_id,
                    Code = park.num_prk,
                    Name = park.name_park_r,
                    StationCode = park.stanc
                };
                if (park is null)
                {
                    throw new ArgumentException($"Парк {code} станции {station}  не был найден");
                }
                IList<way> routesDTO = _routeRepository.GetByCode(stationPark.Id, code);
                List<Route> routes = new List<Route>();
                foreach (var route in routesDTO)
                {
                    Route _route = new Route
                    {
                        Id = route.way_id,
                        CarCount = route.kvo_vgn,
                        CarWeight = route.ves_sum,
                        CarLength = route.lng_sum,
                        RouteNumber = route.num_way,
                        ParkCode = route.num_prk,
                        ParkId = route.prk_id
                    };
                    routes.Add(_route);
                }
                return Mapper.GetMapperInstance().Map<IEnumerable<Models.RouteModels.Route>>(routes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
