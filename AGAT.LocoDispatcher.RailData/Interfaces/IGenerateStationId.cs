using AGAT.LocoDispatcher.RailData.Models;
namespace AGAT.LocoDispatcher.RailData.Interfaces
{
    interface IGenerateStationId
    {
        int GetStationIdByPark(Point point);
    }
}
