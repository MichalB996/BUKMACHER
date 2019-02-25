﻿using Autofac;
using SportsBetting.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SportsBetting.Infrastructure.IoC.Modules
{
    public class ServiceModule : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ServiceModule).GetTypeInfo().Assembly;
            builder.RegisterAssemblyTypes(assembly).Where(x => x.IsAssignableTo<IService>()).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
