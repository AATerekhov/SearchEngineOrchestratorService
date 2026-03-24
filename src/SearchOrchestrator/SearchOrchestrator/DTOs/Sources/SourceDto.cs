using Orchestrator.Domain.Enums;

namespace SearchOrchestrator.DTOs.Sources
{
    public sealed record SourceDto(
        Guid Id,
        string Name,
        SourceType Type,
        string Location,
        DateTime LastIndexedAt,
        bool IsActive);
}
