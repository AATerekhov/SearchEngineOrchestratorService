using Orchestrator.Domain.SharedKernel;
using Orchestrator.Domain.ValueObjects;

namespace Orchestrator.Domain.Aggregates
{
    public class Source : AggregateRoot<SourceId>
    {
        public DateTime LastIndexedAt { get; private set; }
        private Source() : base(SourceId.New()) { } //EF Core
        protected Source(SourceId id) : base(id)
        {
        }
    }
}
