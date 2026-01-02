using Domain.OrderModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessLayer.Configurations.OrderModels
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.Number)
                .IsRequired()
                .HasMaxLength(15);

            builder.HasOne(c => c.Customer)
                .WithOne(o => o.Order)
                .HasForeignKey<Customer>("OrderId");

            builder.Property(o => o.CreationDate)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(o => o.ExecutionDate)
                .IsRequired();

            builder.Property<Guid>("OrderTypeId")
                .IsRequired();

            builder.Property(o => o.CountPayments)
                .IsRequired()
                .HasDefaultValue(1);

            builder.Property<Guid>("OrderCreatorId")
                .IsRequired();

            builder.Property<Guid>("DepartmentMakingOrderId")
                .IsRequired();

            builder.Property<Guid>("DepartmentOfExecutionId")
                .IsRequired();

            // Explicitly configure relationships with Department to avoid ambiguous multiple navigations
            builder.HasOne(o => o.DepartmentMakingOrder)
                .WithMany(d => d.DepartmentMaking)
                .HasForeignKey("DepartmentMakingOrderId");

            builder.HasOne(o => o.DepartmentOfExecution)
                .WithMany(d => d.DepartmentOfExecution)
                .HasForeignKey("DepartmentOfExecutionId");

            builder.Property(o => o.Description)
                .IsRequired(false)
                .HasMaxLength(1500);

            builder.Property(o => o.Verified)
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}
