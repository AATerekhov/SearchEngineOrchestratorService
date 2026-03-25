namespace Orchestrator.Application.Abstractions.Contracts
{
    public sealed record StartIndexingResult
    {
        public string ExternalOperationId = default!;
        public string Status = default!;
    }
}
