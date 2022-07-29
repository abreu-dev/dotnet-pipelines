using AutoMapper;
using Pipelines.Domain.DomainEntities;
using Pipelines.Domain.Repositories;
using Pipelines.Infra.Data.Context;
using Pipelines.Infra.Data.Models;

namespace Pipelines.Infra.Data.Repositories
{
    public class ProductRepository : Repository<ProductDomainEntity, ProductDataEntity>, IProductRepository
    {
        public ProductRepository(IDataContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
