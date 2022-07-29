using Microsoft.EntityFrameworkCore;
using Pipelines.Infra.Data.Mappings;
using Pipelines.Infra.Data.Models;
using System.Reflection;

namespace Pipelines.Infra.Data.Context
{
    public class PipelinesDbContext : DbContext
    {
        public PipelinesDbContext(DbContextOptions<PipelinesDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
