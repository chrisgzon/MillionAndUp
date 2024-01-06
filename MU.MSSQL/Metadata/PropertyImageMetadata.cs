using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MU.Domain.Entities;

namespace MU.MSSQL.Metadata
{
    public class PropertyImageMetadata : IEntityTypeConfiguration<PropertyImage>
    {
        public void Configure(EntityTypeBuilder<PropertyImage> builder)
        {
            builder.ToTable("PropertyImage").HasKey(p => p.IdPropertyImage);

            #region table properties
            builder.Property(p => p.File).HasMaxLength(250);
            #endregion table properties

            #region relationships
            builder.HasOne(e => e.Property).WithMany(e => e.PropertyImages).HasForeignKey(e => e.IdProperty).IsRequired();
            #endregion relationships
        }
    }
}
