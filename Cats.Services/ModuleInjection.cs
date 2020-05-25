using Cats.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Cats.Services
{
    public static class ModuleInjection
    {
        public static ServiceCollection AddServices(this ServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();
            return services;
        }
    }
}
