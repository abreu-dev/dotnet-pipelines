using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pipelines.Infra.Data.Models;

namespace Pipelines.Infra.Data.Mappings
{
    public class ProductDataEntityMapping : IEntityTypeConfiguration<ProductDataEntity>
    {
        public void Configure(EntityTypeBuilder<ProductDataEntity> builder)
        {
            builder.ToTable(ProductDataEntity.TableName);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(ProductDataEntity.NameMaxLength);
        }
    }
}
