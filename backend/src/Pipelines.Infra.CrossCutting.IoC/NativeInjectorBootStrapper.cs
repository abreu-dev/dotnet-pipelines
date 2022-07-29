using Microsoft.Extensions.DependencyInjection;
using Pipelines.Infra.Data.Context;

namespace Pipelines.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Infra - Data - Contexts
            services.AddScoped<PipelinesDbContext>();
        }
    }
}
