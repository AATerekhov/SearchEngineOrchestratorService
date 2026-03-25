namespace Orchestrator.Application.Abstractions.Contracts
{
    public sealed record StartIndexingRequest
    {
        public Guid SourceId;
        public string SourceName = default!;
        public string SourceType = default!;
        public string Location = default!;
        public bool ForceReindex;
        public string CorrelationId = default!;
    }
}
