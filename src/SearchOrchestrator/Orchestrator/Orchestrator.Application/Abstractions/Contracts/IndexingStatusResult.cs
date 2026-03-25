namespace Orchestrator.Application.Abstractions.Contracts
{
    public sealed record IndexingStatusResult
    {
        public string ExternalOperationId = default!;
        public string Status = default!;
        public int ProcessedFiles;
        public int IndexedFiles;
        public int FailedFiles;
        public string? ErrorMessage;
    }
}
