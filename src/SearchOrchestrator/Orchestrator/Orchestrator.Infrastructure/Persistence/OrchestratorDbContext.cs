using Microsoft.EntityFrameworkCore;
using Orchestrator.Domain.Aggregates;

namespace Orchestrator.Infrastructure.Persistence
{
    public sealed class OrchestratorDbContext(DbContextOptions<OrchestratorDbContext> options) : DbContext(options)
    {
        public DbSet<Source> Sources => Set<Source>();
        public DbSet<IndexJob> IndexJobs => Set<IndexJob>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrchestratorDbContext).Assembly);
        }
    }
}
