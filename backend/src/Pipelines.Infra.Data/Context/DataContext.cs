using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Pipelines.Infra.Data.Models;
using System.Reflection;

namespace Pipelines.Infra.Data.Context
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<TDataEntity> GetDbSet<TDataEntity>() where TDataEntity : DataEntity
        {
            return Set<TDataEntity>();
        }

        public EntityEntry<TDataEntity> GetDbEntry<TDataEntity>(TDataEntity entity) where TDataEntity : DataEntity
        {
            return Entry(entity);
        }

        public void AddData<TDataEntity>(TDataEntity entity) where TDataEntity : DataEntity
        {
            Add(entity);
        }

        public void UpdateData<TDataEntity>(TDataEntity entity) where TDataEntity : DataEntity
        {
            Update(entity);
        }

        public void DeleteData<TDataEntity>(TDataEntity entity) where TDataEntity : DataEntity
        {
            Remove(entity);
        }

        public void Complete()
        {
            SaveChanges();
        }
    }
}
