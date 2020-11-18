using AGAT.LocoDispatcher.Business.Models.RailModels;
using AGAT.LocoDispatcher.RailData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Business.Managers
{
    public class PointManager
    {
        private PointRepository _repository;
        public PointManager()
        {
            _repository = new PointRepository();
        }
        public IEnumerable<Point> GetPointsByParkId(int parkId)
        {
            try
            {
                IEnumerable<RailData.Models.Point> _points = _repository.GetById(parkId);
                IEnumerable<Point> points = Mapper.GetMapperInstance().Map<IEnumerable<Point>>(_points);
                var _p = points.Where(e => e.Angle > 0).ToList();
                return points;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CreatePoints(int parkId, Point point)
        {
            try
            {
                RailData.Models.Point _point = Mapper.GetMapperInstance().Map<RailData.Models.Point>(point);
                _point.ParkId = parkId;
                _repository.Create(_point);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Point> GetPointByCode(string checkpoint, int parkId)
        {
            try
            {
                RailData.Models.Point _point = await _repository.GetByCode(checkpoint, parkId);
                Point point = Mapper.GetMapperInstance().Map<Point>(_point);
                return point;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
