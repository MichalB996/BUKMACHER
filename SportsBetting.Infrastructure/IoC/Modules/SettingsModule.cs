﻿using Autofac;
using Microsoft.Extensions.Configuration;
using SportsBetting.Infrastructure.Extensions;
using SportsBetting.Infrastructure.Settings;

namespace SportsBetting.Infrastructure.IoC.Modules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<GeneralSettings>()).SingleInstance();
        }
    }
}
