using Orchestrator.Domain.Aggregates;
using Orchestrator.Domain.Repositories;
using Orchestrator.Domain.ValueObjects;

namespace Orchestrator.Infrastructure.Persistence.Repositories
{
    internal sealed class InMemorySourceRepository(InMemoryStore store) : ISourceRepository
    {
        public Task AddAsync(Source source, CancellationToken ct = default)
        {
            store.Sources[source.Id.Value] = source;
            return Task.CompletedTask;
        }

        public Task<Source?> GetByIdAsync(SourceId id, CancellationToken ct = default)
        {
            store.Sources.TryGetValue(id.Value, out var source);
            return Task.FromResult(source);
        }
    }
}
