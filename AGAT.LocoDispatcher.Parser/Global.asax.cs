using AGAT.LocoDispatcher.Parser.Utils.Schedulers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AGAT.LocoDispatcher.Parser
{
    public class WebApiApplication : HttpApplication
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        protected void Application_Start()
        {
            logger.Info($"App was launched in {DateTime.Now}");
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ParseScheduler.Start(ConfigurationManager.AppSettings["path"]);
        }
    }
}
