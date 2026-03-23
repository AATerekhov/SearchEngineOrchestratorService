using Orchestrator.Domain.SharedKernel;
using Orchestrator.Domain.ValueObjects;

namespace Orchestrator.Domain.Aggregates
{
    public class IndexJob : AggregateRoot<IndexJobId>
    {
        private IndexJob() : base(IndexJobId.New()) { } //EF Core
        public IndexJob(IndexJobId id) : base(id)
        {
        }
    }
}
