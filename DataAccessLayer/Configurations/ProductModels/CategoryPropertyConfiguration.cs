using Domain.ProductModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessLayer.Configurations.ProductModels
{
    internal class CategoryPropertyConfiguration : IEntityTypeConfiguration<CategoryProperty>
    {
        public void Configure(EntityTypeBuilder<CategoryProperty> builder)
        {
            builder.Property<Guid>("CategoryId")
                .IsRequired();

            builder.Property<Guid>("PropertyId")
                .IsRequired();
        }
    }
}
