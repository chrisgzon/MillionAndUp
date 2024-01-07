using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MU.Domain.Entities.Owners;
using MU.Domain.Entities.Properties;
using MU.Domain.ValueObjects;

namespace MU.Infrastructure.Metadata
{
    public class PropertyMetadata : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable("Property").HasKey(p => p.IdProperty);

            #region table properties
            builder.Property(p => p.IdProperty).HasConversion(
                propertyId => propertyId.Value,
                value => new PropertyId(value));
            builder.Property(p => p.CodeInternal).HasMaxLength(50).IsRequired();
            builder.Property(p => p.PriceSale).HasPrecision(28, 6);
            builder.Property(p => p.Name).HasMaxLength(250);
            builder.Property(p => p.IdOwner).HasConversion(
                ownerId => ownerId.Value,
                value => new OwnerId(value)
            );

            builder.Property(p => p.CodeInternal).HasConversion(
                codeInternal => codeInternal.Value,
                value => InternalCodeProperty.SetInternalCode(value)!
            );
            builder.OwnsOne(p => p.Address, addressBuilder =>
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
            builder.HasOne(p => p.Owner).WithMany(o => o.Properties).HasForeignKey(p => p.IdOwner).IsRequired();
            builder.HasMany(p => p.PropertyImages).WithOne(i => i.Property).HasForeignKey(p => p.IdProperty);
            builder.HasMany(p => p.PropertyTraces).WithOne(i => i.Property).HasForeignKey(p => p.IdProperty);
            #endregion relationships
        }
    }
}
