using Domain.OrderModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessLayer.Configurations.OrderModels
{
    internal class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.Property<Guid>("OrderId")
                .IsRequired();

            builder.Property(op => op.Group)
                .IsRequired()
                .HasDefaultValue(1);

            builder.Property<Guid>("ProductId")
                .IsRequired();

            builder.Property(op => op.Quantity)
                .IsRequired();

            builder.Property(op => op.Price)
                .IsRequired();
        }
    }
}
