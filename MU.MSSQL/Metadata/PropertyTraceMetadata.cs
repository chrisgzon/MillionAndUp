using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MU.Domain.Entities;

namespace MU.MSSQL.Metadata
{
    public class PropertyTraceMetadata : IEntityTypeConfiguration<PropertyTrace>
    {
        public void Configure(EntityTypeBuilder<PropertyTrace> builder)
        {
            builder.ToTable("PropertyTrace").HasKey(p => p.IdPropertyTrace);

            #region table properties
            builder.Property(p => p.NameClient).HasMaxLength(250);
            builder.Property(p => p.Tax).HasPrecision(10, 2);
            builder.Property(p => p.Value).HasPrecision(28, 6);
            #endregion table properties


            #region relationships
            builder.HasOne(e => e.Property).WithMany(e => e.PropertyTraces).HasForeignKey(e => e.IdProperty).IsRequired();
            #endregion relationships
        }
    }
}