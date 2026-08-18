
using Domain.Entities;
using Domain.Entities.Base;
using Infrastructure.Extensions.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;

namespace Infrastructure.Context
{
    public class PersistenceContext : DbContext
    {
        public PersistenceContext(
            DbContextOptions<PersistenceContext> options,
            IOptions<DatabaseSettings> databaseSettings
        ) : base(options)
        {
        }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Professor> Professor { get; set; }

        public async Task CommitAsync()
        {
            await SaveChangesAsync().ConfigureAwait(false);
        }

        protected override void OnModelCreating(ModelBuilder? modelBuilder)
        {
            if (modelBuilder == null)
            {
                return;
            }
            
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                Type t = entityType.ClrType;
                if (!typeof(DomainEntity).IsAssignableFrom(t)) continue;
                modelBuilder.Entity(entityType.Name).Property<DateTime>("CreatedOn").HasDefaultValueSql("GETDATE()");
                modelBuilder.Entity(entityType.Name).Property<DateTime>("LastModifiedOn").HasDefaultValueSql("GETDATE()");
            }
            modelBuilder.AppendGlobalQueryFilter<ISoftDelete>(s => s.DeletedOn == null);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
