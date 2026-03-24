using Orchestrator.Domain.Enums;

namespace SearchOrchestrator.DTOs.IndexJobs
{
    public sealed record IndexJobDto(
        Guid Id,
        Guid SourceId,
        IndexJobType Type,
        IndexJobStatus Status,
        DateTime CreatedAt,
        DateTime StartedAt,
        DateTime CompletedAt,
        int AttemptCount,
        string LastError,
        Guid ExternalOperationId,
        Guid IdempotencyKey,
        Guid CorrelationId);
}
