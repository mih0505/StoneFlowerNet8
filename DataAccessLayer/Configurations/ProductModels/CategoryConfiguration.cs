using Domain.ProductModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessLayer.Configurations.ProductModels
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property<Guid?>("ParentId")
                .IsRequired(false);

            builder.Property(o => o.Name)
                .IsRequired()
                .HasMaxLength(100);


        }
    }
}
