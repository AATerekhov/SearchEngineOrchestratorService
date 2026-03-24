using Orchestrator.Domain.Enums;

namespace SearchOrchestrator.DTOs.Sources
{
    public sealed record CreateSourceRequestDto(
        string Name,
        SourceType Type,
        string Location,
        bool IsActive = true);
}
