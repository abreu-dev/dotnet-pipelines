using Microsoft.Extensions.DependencyInjection;
using Pipelines.Domain.Repositories;
using Pipelines.Infra.Data.Context;
using Pipelines.Infra.Data.Repositories;

namespace Pipelines.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Infra - Data - Contexts
            services.AddScoped<IDataContext, DataContext>();
            services.AddScoped<DataContext>();

            // Infra - Data - Repositories
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
