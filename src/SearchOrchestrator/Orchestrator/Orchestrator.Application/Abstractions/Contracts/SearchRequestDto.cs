namespace Orchestrator.Application.Abstractions.Contracts
{
    public sealed record SearchRequestDto
    {
        public string Query = default!;
        public Guid? SourceId;
        public int Page = 1;
        public int PageSize = 20;
    }
}
