using Pipelines.Infra.Data.Repositories;

namespace Pipelines.Api.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(map =>
            {
                AutoMapperRepository.RegisterMapping(map);
            });
        }
    }
}
