using Microsoft.EntityFrameworkCore;
using Orchestrator.Domain.Aggregates;
using Orchestrator.Domain.Repositories;
using Orchestrator.Domain.ValueObjects;

namespace Orchestrator.Infrastructure.Persistence.Repositories
{
    internal sealed class EfSourceRepository(OrchestratorDbContext dbContext) : ISourceRepository
    {
        public Task AddAsync(Source source, CancellationToken ct = default)
        {
            return dbContext.Sources.AddAsync(source, ct).AsTask();
        }

        public Task<Source?> GetByIdAsync(SourceId id, CancellationToken ct = default)
        {
            return dbContext.Sources
                .SingleOrDefaultAsync(source => source.Id == id, ct);
        }

        public async Task<IReadOnlyDictionary<Guid, Source>> GetByIdAsync(IReadOnlyCollection<Guid> ids, CancellationToken ct = default)
        {
            if (ids.Count == 0)
            {
                return new Dictionary<Guid, Source>();
            }

            var sources = await dbContext.Sources
                .Where(source => ids.Contains(source.Id.Value))
                .ToListAsync(ct);

            return sources.ToDictionary(source => source.Id.Value);
        }
    }
}
