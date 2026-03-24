using Orchestrator.Application.Abstractions;
using Orchestrator.Domain.Aggregates;
using Orchestrator.Domain.Enums;

namespace Orchestrator.Application.Commands.CreateSource
{
    public sealed record CreateSourceCommand(
        string Name,
        SourceType Type,
        string Location,
        bool IsActive) : ICommand<Source>;
}
