using Domain.OrderModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessLayer.Configurations.OrderModels
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.OwnsOne(c => c.CustomerName, customer =>
            {
                customer.Property(c => c.Lastname)
                .IsRequired()
                .HasMaxLength(128);

                customer.Property(c => c.Firstname)
                .IsRequired()
                .HasMaxLength(128);

                customer.Property(c => c.Middlename)
                .IsRequired(false)
                .HasMaxLength(128);
            });

            builder.Property(c => c.BirthDate)
                .IsRequired();

            builder.OwnsOne(c => c.Passport, passport =>
            {
                passport.Property(c => c.Series)
                .IsRequired(false)
                .HasMaxLength(60);

                passport.Property(c => c.Number)
                .IsRequired(false)
                .HasMaxLength(15);

                passport.Property(c => c.Issued)
                .IsRequired(false)
                .HasMaxLength(256);
            });

            builder.OwnsOne(c => c.Address, address =>
            {
                address.Property(c => c.City)
                .IsRequired()
                .HasMaxLength(128);

                address.Property(c => c.Street)
                .IsRequired()
                .HasMaxLength(128);

                address.Property(c => c.House)
                .IsRequired()
                .HasMaxLength(128);

                address.Property(c => c.Float)
                .IsRequired(false)
                .HasMaxLength(128);
            });

            builder.OwnsOne(c => c.PhoneNumbers, phones =>
            {
                phones.Property(p => p.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15);

                phones.Property(p => p.AdvancedPhoneNumber)
                .IsRequired(false)
                .HasMaxLength(15);
            });

            builder.HasKey("OrderId");

            builder.Property<Guid>("OrderId")
                .IsRequired();       
        }
    }
}
