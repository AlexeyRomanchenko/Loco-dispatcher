﻿using AGAT.LocoDispatcher.Business.Managers;
using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

            // регистрируем споставление типов
            builder.RegisterType<RoutesManager>().As<RoutesManager>();
            builder.RegisterType<RailsManager>().As<RailsManager>();
            builder.RegisterType<RailsManager>().As<RailsManager>();

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}