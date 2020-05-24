using Cats.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Cats.Common
{
    public static class ModuleInjection
    {
        public static ServiceCollection AddCommonServices(this ServiceCollection services)
        {
            services.AddScoped<IHttpWrapper, HttpWrapper>();
            return services;
        }
    }
}
