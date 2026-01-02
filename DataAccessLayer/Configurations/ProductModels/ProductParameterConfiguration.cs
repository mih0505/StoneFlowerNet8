using Domain.ProductModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessLayer.Configurations.ProductModels
{
    internal class ProductParameterConfiguration : IEntityTypeConfiguration<ProductParameter>
    {
        public void Configure(EntityTypeBuilder<ProductParameter> builder)
        {
            builder.Property<Guid>("ProductId")
                .IsRequired();

            builder.Property<Guid>("PropertyId")
                .IsRequired();

            builder.Property(p => p.Value)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
