using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MU.Domain.Entities;

namespace MU.MSSQL.Metadata
{
    internal class OwnerMetadata : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("Owner").HasKey(o => o.IdOwner);

            #region table properties
            builder.Property(p => p.Name).HasMaxLength(250);
            builder.Property(p => p.Address).HasMaxLength(250);
            builder.Property(p => p.Photo).HasMaxLength(250);
            #endregion table properties

            #region relationships
            builder.HasMany(e => e.Properties).WithOne(e => e.Owner).HasForeignKey(e => e.IdProperty).IsRequired();
            #endregion relationships
        }
    }
}
