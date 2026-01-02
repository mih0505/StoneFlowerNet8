using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessLayer.Configurations.Common
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Code)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property<Guid>("OrganizationId")
               .IsRequired();

            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(128);

            builder.OwnsOne(d => d.Address, address =>
            {
                address.Property(c => c.City)
                .IsRequired(false)
                .HasMaxLength(128);

                address.Property(c => c.Street)
                .IsRequired(false)
                .HasMaxLength(128);

                address.Property(c => c.House)
                .IsRequired()
                .HasMaxLength(10);

                address.Property(c => c.Float)
                .IsRequired(false);
            });

            builder.OwnsOne(d => d.PhoneNumbers, phones =>
            {
                phones.Property(p => p.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15);

                phones.Property(p => p.AdvancedPhoneNumber)
                .IsRequired(false)
                .HasMaxLength(15);
            });

            builder.Property(d => d.Email)
                .IsRequired(false)
                .HasMaxLength(128);
        }
    }
}
