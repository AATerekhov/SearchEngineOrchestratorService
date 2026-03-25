namespace Orchestrator.Application.Abstractions.Contracts
{
    public sealed record CancelIndexingResult
    {
        public string ExternalOperationId = default!;
        public string Status = default!;
    }
}
