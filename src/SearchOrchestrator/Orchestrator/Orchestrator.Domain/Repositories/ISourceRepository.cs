using Orchestrator.Domain.Aggregates;
using Orchestrator.Domain.ValueObjects;

namespace Orchestrator.Domain.Repositories
{
    public interface ISourceRepository
    {
        Task AddAsync(Source source, CancellationToken ct = default);
        Task<Source?> GetByIdAsync(SourceId id, CancellationToken ct = default);
    }
}
