using Domain.OrderModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessLayer.Configurations.OrderModels
{
    internal class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.Property<Guid>("OrderId")
                .IsRequired();

            builder.Property(o => o.Date)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(o => o.Pay)
                .IsRequired();

            builder.Property<Guid>("DepartmentId")
               .IsRequired();

            builder.Property<Guid>("UserId")
               .IsRequired();
        }
    }
}
