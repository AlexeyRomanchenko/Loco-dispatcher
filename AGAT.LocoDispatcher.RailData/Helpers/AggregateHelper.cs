using AGAT.LocoDispatcher.RailData.Models;

namespace AGAT.LocoDispatcher.RailData.Helpers
{
    public static class AggregateHelper
    {
        public static int? GetStationIdByPark(Point point)
        {
            if (point?.Park is null)
            {
                return null;
            }
            else
            {
                return point.Park?.StationId;
            }
        }

        public static (string, string) GetParkdCodeAndRoute(string parkRoute)
        {
            if (string.IsNullOrEmpty(parkRoute?.Trim()))
            {
                return (null, null);
            }
            string park = parkRoute.Substring(0, parkRoute.Length - 2);
            string route = parkRoute.Substring(parkRoute.Length - 2, 2);
            return (park, route);
        }
    }
}
