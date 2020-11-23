using AGAT.LocoDispatcher.Common.Interfaces;

namespace AGAT.LocoDispatcher.Common.Models.EventModels
{
    public class StationInfo : IStationInfo
    {
        public string StationCode { get; set; }
        public int ParkId { get; set; }
        public string Park { get; set; }
        public string Route { get; set; }
    }
}
