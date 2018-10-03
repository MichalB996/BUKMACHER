using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using BUKMACHER_INFRASTRUCTURE.Commands;

namespace BUKMACHER_INFRASTRUCTURE.IoC.Modules
{
    //All configurationfor IoC controller.
    public class CommandModule : Autofac.Module
    {
        // In this class we get the information what is the type of command.
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandModule).GetTypeInfo().Assembly;
            builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(ICommandHandler<>)).InstancePerLifetimeScope();
            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>().InstancePerLifetimeScope();
        }
    }
}
