using System.Collections.Concurrent;
using Orchestrator.Domain.Aggregates;

namespace Orchestrator.Infrastructure.Persistence
{
    internal sealed class InMemoryStore
    {
        public ConcurrentDictionary<Guid, Source> Sources { get; } = new();

        public ConcurrentDictionary<Guid, IndexJob> IndexJobs { get; } = new();
    }
}
