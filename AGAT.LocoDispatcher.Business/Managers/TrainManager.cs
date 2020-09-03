using AGAT.LocoDispatcher.AsusDb.Models;
using AGAT.LocoDispatcher.AsusDb.Repositories;
using AGAT.LocoDispatcher.Common.Interfaces.Managers;
using AGAT.LocoDispatcher.Common.Models;
using AGAT.LocoDispatcher.Common.Models.RailModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Business.Managers
{
    public class TrainManager : ITrainManager
    {
        private TrainRepository _repository;
        private RouteRepository _routeRepository;
        private StationParkRepository _stationParkRepository;

        public TrainManager()
        {
            _repository = new TrainRepository();
            _routeRepository = new RouteRepository();
            _stationParkRepository = new StationParkRepository();
        }
        public async Task<IEnumerable<Train>> GetTrainsAsync(string parkCode, string station)
        {
            try
            {
                if (string.IsNullOrEmpty(station?.Trim()) || string.IsNullOrEmpty(parkCode?.Trim()))
                {
                    throw new ArgumentException($"Код станции или парка не валиден. Код станции {station}, парк {parkCode}");
                }
                park park = await _stationParkRepository.GetParkByStationAndCodeAsync(station, parkCode);
                if (park == null)
                {
                    throw new ArgumentNullException("Парк не найден");
                }
                var wayIds = await _routeRepository.GetWayIdByCodeAsync(park.prk_id, parkCode);
                if (wayIds.Count() < 1)
                {
                    throw new ArgumentNullException("Пути не найдены");
                }
                // Make JOIN
                IList<TrainDTO> info = await _repository.GetTrainsInfoByWayIdsAsync(wayIds);
                return Mapper.GetMapperInstance().Map<IList<Train>>(info);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
