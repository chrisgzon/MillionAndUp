using MediatR;
using Microsoft.EntityFrameworkCore;
using MU.Domain.Entities;
using MU.Domain.Entities.Owners;
using MU.Infrastructure.Metadata;

namespace MU.Infrastructure.Contexts
{
    public class MUContext : DbContext
    {
        private readonly IPublisher _publisher;
        #region tables
        public DbSet<Property> Properties { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }
        public DbSet<PropertyTrace> PropertyTraces { get; set; }
        #endregion tables

        #region constructors
        public MUContext(DbContextOptions<MUContext> options, IPublisher publisher) : base(options) 
        {
            _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
        }
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
