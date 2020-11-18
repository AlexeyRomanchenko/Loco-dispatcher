﻿using System.Web.Http;
using System.Web.Http.Cors;

namespace AGAT.LocoDispatcher.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            EnableCorsAttribute cors = new EnableCorsAttribute("http://localhost:4200," +
                "http://10.19.4.17," +
                "http://10.19.4.17:81," +
                "http://10.19.4.17:82," +
                "http://10.1.3.230," +
                "http://10.1.3.230:81," +
                "http://10.1.3.230:82," +
                "http://10.19.4.17:83", "*", "*");
            cors.SupportsCredentials = true;
            config.EnableCors(cors);
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Formatters.XmlFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("multipart/form-data"));
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
