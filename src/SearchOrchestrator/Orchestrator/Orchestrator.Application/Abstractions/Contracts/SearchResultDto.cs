namespace Orchestrator.Application.Abstractions.Contracts
{
    public sealed record SearchResultDto
    {
        public int Total;
        public IReadOnlyCollection<SearchResultItemDto> Items = [];
    }
}
