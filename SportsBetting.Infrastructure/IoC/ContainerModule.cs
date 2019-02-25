using Autofac;
using Microsoft.Extensions.Configuration;
using SportsBetting.Infrastructure.IoC.Modules;
using SportsBetting.Infrastructure.Mappers;

namespace SportsBetting.Infrastructure.IoC
{
    public class ContainerModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.Initialize()).SingleInstance();
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule( new SettingsModule(_configuration));
        }
    }
}
