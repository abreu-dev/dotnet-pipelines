namespace Pipelines.Domain.DomainEntities
{
    public abstract class DomainEntity
    {
        public Guid Id { get; private set; }

        protected DomainEntity()
        {
            Id = Guid.NewGuid();
        }

        protected DomainEntity(Guid id)
        {
            Id = id;
        }
    }
}
