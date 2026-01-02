using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessLayer.Configurations.Common;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.OwnsOne(u => u.WorkerName, workername =>
        {
            workername.Property(c => c.Lastname)
            .IsRequired()
            .HasMaxLength(128);

            workername.Property(c => c.Firstname)
            .IsRequired()
            .HasMaxLength(128);

            workername.Property(c => c.Middlename)
            .IsRequired(false)
            .HasMaxLength(128);
        });            
    }
}
