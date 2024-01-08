using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MU.Domain.Entities.Owners;

namespace MU.Infrastructure.Metadata
{
    internal class OwnerMetadata : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("Owner").HasKey(o => o.IdOwner);

            #region table properties
            builder.Property(o => o.IdOwner).HasConversion(
                ownerId => ownerId.Value,
                value => new OwnerId(value));
            builder.Property(o => o.Name).HasMaxLength(250);
            builder.Property(o => o.Photo).HasMaxLength(250);

            builder.OwnsOne(o => o.Address, addressBuilder =>
            {
                addressBuilder.Property(a => a.City).HasMaxLength(150).IsRequired();
                addressBuilder.Property(a => a.State).HasMaxLength(150).IsRequired();
                addressBuilder.Property(a => a.Line1).HasMaxLength(150);
                addressBuilder.Property(a => a.Line2).HasMaxLength(150);
                addressBuilder.Property(a => a.ZipCode).HasMaxLength(150).IsRequired();
                addressBuilder.Ignore(p => p.AddressString);
            });
            #endregion table properties

            #region relationships
            builder.HasMany(e => e._properties).WithOne(e => e.Owner).HasForeignKey(e => e.IdOwner).IsRequired();
            #endregion relationships
        }
    }
}
