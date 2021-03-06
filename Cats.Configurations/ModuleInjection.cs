﻿using Cats.Configurations;
using Cats.Domain.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace Cats.Common
{
    public static class ModuleInjection
    {
        public static ServiceCollection AddConfigServices(this ServiceCollection services)
        {
            services.AddScoped<IConfiguration, Configuration>();
            return services;
        }
    }
}
