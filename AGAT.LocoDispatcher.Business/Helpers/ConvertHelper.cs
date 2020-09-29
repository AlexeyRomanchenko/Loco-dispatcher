using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Business.Helpers
{
    public class ConvertHelper
    {
        public static (string, string) ConvertToParkAndRoute(string parkRoute)
        {
            try
            {
                if (string.IsNullOrEmpty(parkRoute?.Trim()))
                {
                    throw new ArgumentNullException("Парк-путь не валидные");
                }
                string park = parkRoute.Substring(0, parkRoute.Length - 2);
                string route = parkRoute.Substring(parkRoute.Length - 2, 2);
                return (park, route);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
