namespace Orchestrator.Application.Abstractions.Contracts
{
    public sealed record SearchResultItemDto
    {
        public string DocumentId = default!;
        public string FileName = default!;
        public string Snippet = default!;
        public double Score;
    }
}
