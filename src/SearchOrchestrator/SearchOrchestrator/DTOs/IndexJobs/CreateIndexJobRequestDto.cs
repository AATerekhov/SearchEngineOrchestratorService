using Orchestrator.Domain.Enums;

namespace SearchOrchestrator.DTOs.IndexJobs
{
    public sealed record CreateIndexJobRequestDto(
        Guid SourceId,
        IndexJobType Type,
        Guid? IdempotencyKey,
        Guid? CorrelationId);
}
