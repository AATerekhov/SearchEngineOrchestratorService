using Orchestrator.Application.Abstractions;
using Orchestrator.Domain.Aggregates;

namespace Orchestrator.Application.Queries.GetIndexJob
{
    public sealed record GetIndexJobQuery(Guid Id) : IQuery<IndexJob?>;
}
