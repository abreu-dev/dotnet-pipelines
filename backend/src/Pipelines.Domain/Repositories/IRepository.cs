using Pipelines.Domain.DomainEntities;

namespace Pipelines.Domain.Repositories
{
    public interface IRepository<TDomainEntity> where TDomainEntity : DomainEntity
    {
        IUnitOfWork UnitOfWork { get; }

        IEnumerable<TDomainEntity> GetAll();
        TDomainEntity GetById(Guid id);

        void Add(TDomainEntity entity);
        void Update(TDomainEntity entity);
        void Delete(Guid id);
    }
}
