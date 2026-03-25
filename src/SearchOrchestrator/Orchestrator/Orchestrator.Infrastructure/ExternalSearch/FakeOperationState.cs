namespace Orchestrator.Infrastructure.ExternalSearch
{
    internal sealed class FakeOperationState
    {
        public string ExternalOperationId { get; init; } = default!;
        public Guid SourceId { get; init; }
        public string SourceName { get; init; } = default!;
        public FakeSearchBehavior Behavior { get; init; }
        public string Status { get; set; } = default!;
        public int PollCount { get; set; }
    }
}
