using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MU.Domain.Entities;

namespace MU.MSSQL.Metadata
{
    public class PropertyMetadata : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable("Property").HasKey(p => p.IdProperty);

            #region table properties
            builder.Property(p => p.Address).HasMaxLength(250);
            builder.Property(p => p.CodeInternal).HasMaxLength(50);
            builder.Property(p => p.PriceSale).HasPrecision(28, 6);
            builder.Property(p => p.Name).HasMaxLength(250);
            #endregion table properties

            #region relationships
            builder.HasOne(p => p.Owner).WithMany(o => o.Properties).HasForeignKey(p => p.IdOwner).IsRequired();
            builder.HasMany(p => p.PropertyImages).WithOne(i => i.Property).HasForeignKey(p => p.IdProperty);
            builder.HasMany(p => p.PropertyTraces).WithOne(i => i.Property).HasForeignKey(p => p.IdProperty);
            #endregion relationships
        }
    }
}
