using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AGAT.LocoDispatcher.Parser.Utils.Helpers
{
    public class ConvertHelper
    {
        public static DateTime TimestampToDateTime(int timestamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(timestamp).ToLocalTime();
            return dtDateTime;
        }

        public static double DynamicToDouble(dynamic value)
        {
            try
            {
                double doubleCount;
                bool isDouble = double.TryParse(value.ToString(), NumberStyles.Number, CultureInfo.InvariantCulture, out doubleCount);
                if (!isDouble)
                {
                    doubleCount = 0;
                }
                return doubleCount;
            }
            catch (InvalidCastException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}