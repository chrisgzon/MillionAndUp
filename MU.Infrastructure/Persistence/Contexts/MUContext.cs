using MediatR;
using Microsoft.EntityFrameworkCore;
using MU.Domain.Entities.Owners;
using MU.Domain.Entities.Properties;
using MU.Domain.Entities.PropertyImages;
using MU.Domain.Entities.PropertyTraces;
using MU.Domain.Primitives;
using MU.Infrastructure.Metadata;

namespace MU.Infrastructure.Contexts
{
    public class MUContext : DbContext, IUnitOfWork
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

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            IEnumerable<INotification> domainEvents = ChangeTracker.Entries<AggregateRoot>()
                .Select(e => e.Entity)
                .Where(e => e.GetDomainEvents().Any())
                .SelectMany(e => e.GetDomainEvents());

            int result = await base.SaveChangesAsync(cancellationToken);

            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent, cancellationToken);
            }

            return result;
        }
    }
}
