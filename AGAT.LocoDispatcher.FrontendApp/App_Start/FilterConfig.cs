using System.Web;
using System.Web.Mvc;

namespace AGAT.LocoDispatcher.FrontendApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
