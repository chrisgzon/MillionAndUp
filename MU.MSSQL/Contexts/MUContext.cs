using Microsoft.EntityFrameworkCore;
using MU.Domain.Entities;
using MU.MSSQL.Metadata;

namespace MU.MSSQL.Contexts
{
    public class MUContext : DbContext
    {
        #region tables
        public DbSet<Property> Properties { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }
        public DbSet<PropertyTrace> PropertyTraces { get; set; }
        #endregion tables

        #region constructors
        public MUContext(DbContextOptions<MUContext> options) : base(options) { }
        #endregion

        #region configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PropertyMetadata());
            modelBuilder.ApplyConfiguration(new OwnerMetadata());
            modelBuilder.ApplyConfiguration(new PropertyImageMetadata());
            modelBuilder.ApplyConfiguration(new PropertyTraceMetadata());
        }
        #endregion configuration
    }
}
