namespace Pipelines.Domain.Repositories
{
    public interface IUnitOfWork
    {
        void Complete();
    }
}
