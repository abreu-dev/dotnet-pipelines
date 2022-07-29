namespace Pipelines.Domain.DomainEntities
{
    public class ProductDomainEntity : DomainEntity
    {
        public string Name { get; private set; }

        public ProductDomainEntity(string name)
        {
            Name = name;
        }

        public ProductDomainEntity(Guid id, string name) : base(id)
        {
            Name = name;
        }

    }
}
