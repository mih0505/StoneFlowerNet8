using Domain.OrderModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessLayer.Configurations.OrderModels
{
    internal class DeceasedConfiguration : IEntityTypeConfiguration<Deceased>
    {
        public void Configure(EntityTypeBuilder<Deceased> builder)
        {
            builder.Property<Guid>("OrderId")
                .IsRequired();

            builder.OwnsOne(c => c.DeceasedName, deceased =>
            {
                deceased.Property(c => c.Lastname)
                .IsRequired()
                .HasMaxLength(128);

                deceased.Property(c => c.Firstname)
                .IsRequired()
                .HasMaxLength(128);

                deceased.Property(c => c.Middlename)
                .IsRequired(false)
                .HasMaxLength(128);
            });

            builder.Property(d => d.BirthDate)
                 .IsRequired(false)
                 .HasMaxLength(10);

            builder.Property(d => d.DeathDate)
                 .IsRequired(false)
                 .HasMaxLength(10);
        }
    }
}
