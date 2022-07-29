using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Pipelines.Domain.Repositories;
using Pipelines.Infra.Data.Models;

namespace Pipelines.Infra.Data.Context
{
    public interface IDataContext : IUnitOfWork
    {
        DbSet<TDataEntity> GetDbSet<TDataEntity>() where TDataEntity : DataEntity;
        EntityEntry<TDataEntity> GetDbEntry<TDataEntity>(TDataEntity entity) where TDataEntity : DataEntity;

        void AddData<TDataEntity>(TDataEntity entity) where TDataEntity : DataEntity;
        void UpdateData<TDataEntity>(TDataEntity entity) where TDataEntity : DataEntity;
        void DeleteData<TDataEntity>(TDataEntity entity) where TDataEntity : DataEntity;
    }
}
