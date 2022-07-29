using AutoMapper;
using Pipelines.Domain.DomainEntities;
using Pipelines.Infra.Data.Models;

namespace Pipelines.Infra.Data.Repositories
{
    public static class AutoMapperRepository
    {
        public static void RegisterMapping(IMapperConfigurationExpression map)
        {
            RegisterProductMapper(map);
        }

        private static void RegisterProductMapper(IMapperConfigurationExpression map)
        {
            map.CreateMap<ProductDomainEntity, ProductDataEntity>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));

            map.CreateMap<ProductDataEntity, ProductDomainEntity>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));
        }
    }
}
