using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MU.Domain.Entities.Properties;
using MU.Domain.Entities.PropertyImages;

namespace MU.Infrastructure.Metadata
{
    public class PropertyImageMetadata : IEntityTypeConfiguration<PropertyImage>
    {
        public void Configure(EntityTypeBuilder<PropertyImage> builder)
        {
            builder.ToTable("PropertyImage").HasKey(p => p.IdPropertyImage);

            #region table properties
            builder.Property(p => p.IdPropertyImage).HasConversion(
                propertyImageId => propertyImageId.Value,
                value => new PropertyImageId(value));
            builder.Property(p => p.IdProperty).HasConversion(
                propertyId => propertyId.Value,
                value => new PropertyId(value));
            builder.Property(p => p.File).HasMaxLength(250);

            builder.Ignore(p => p.FileData);
            builder.Ignore(p => p.FileLength);
            builder.Ignore(p => p.PathFolder);
            #endregion table properties

            #region relationships
            builder.HasOne(e => e.Property).WithMany(e => e.PropertyImages).HasForeignKey(e => e.IdProperty).IsRequired();
            #endregion relationships
        }
    }
}
