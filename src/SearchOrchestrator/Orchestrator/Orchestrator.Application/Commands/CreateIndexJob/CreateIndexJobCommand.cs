using Orchestrator.Application.Abstractions;
using Orchestrator.Domain.Aggregates;
using Orchestrator.Domain.Enums;

namespace Orchestrator.Application.Commands.CreateIndexJob
{
    public sealed record CreateIndexJobCommand(
        Guid SourceId,
        IndexJobType Type,
        Guid IdempotencyKey,
        Guid CorrelationId) : ICommand<IndexJob>;
}
