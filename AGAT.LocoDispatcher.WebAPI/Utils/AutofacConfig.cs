using AGAT.LocoDispatcher.Business.Managers;
using AGAT.LocoDispatcher.Common.Interfaces.Managers;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace AGAT.LocoDispatcher.WebAPI.Utils
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // регистрируем контроллер в текущей сборке
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);

            // регистрируем споставление типов
            builder.RegisterType<RoutesManager>().As<IRouteManager>();
            builder.RegisterType<RailsManager>().As<IRailManager>();
            builder.RegisterType<TrainManager>().As<ITrainManager>();
            builder.RegisterType<LocoManager>().As<LocoManager>();
            builder.RegisterType<PointManager>().As<PointManager>();
            builder.RegisterType<CarriageManager>().As<CarriageManager>();

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver =
    new AutofacWebApiDependencyResolver(container);
        }
    }
}