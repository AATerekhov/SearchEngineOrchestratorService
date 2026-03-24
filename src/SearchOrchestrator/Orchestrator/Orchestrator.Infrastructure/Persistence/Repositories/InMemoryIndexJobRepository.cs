using Orchestrator.Domain.Aggregates;
using Orchestrator.Domain.Repositories;
using Orchestrator.Domain.ValueObjects;

namespace Orchestrator.Infrastructure.Persistence.Repositories
{
    internal sealed class InMemoryIndexJobRepository(InMemoryStore store) : IIndexJobRepository
    {
        public Task AddAsync(IndexJob indexJob, CancellationToken ct = default)
        {
            store.IndexJobs[indexJob.Id.Value] = indexJob;
            return Task.CompletedTask;
        }

        public Task<IndexJob?> GetByIdAsync(IndexJobId id, CancellationToken ct = default)
        {
            store.IndexJobs.TryGetValue(id.Value, out var indexJob);
            return Task.FromResult(indexJob);
        }
    }
}
