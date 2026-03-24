using Orchestrator.Domain.Aggregates;
using Orchestrator.Domain.ValueObjects;

namespace Orchestrator.Domain.Repositories
{
    public interface IIndexJobRepository
    {
        Task AddAsync(IndexJob indexJob, CancellationToken ct = default);
        Task<IndexJob?> GetByIdAsync(IndexJobId id, CancellationToken ct = default);
    }
}
