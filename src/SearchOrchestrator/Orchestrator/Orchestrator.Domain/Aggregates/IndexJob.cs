using Orchestrator.Domain.Enums;
using Orchestrator.Domain.SharedKernel;
using Orchestrator.Domain.ValueObjects;

namespace Orchestrator.Domain.Aggregates
{
    public class IndexJob : AggregateRoot<IndexJobId>
    {
        public Guid SourceId { get; private set; }
        public IndexJobType Type { get; private set; }
        public IndexJobStatus Status { get; private set; }
        public DateTimeOffset CreatedAt { get; private set; }
        public DateTimeOffset StartedAt { get; private set; }
        public DateTimeOffset CompletedAt { get; private set; }
        public int AttemptCount { get; private set; }
        public string LastError { get; private set; } = default!;
        public Guid ExternalOperationId { get; private set; }
        public Guid IdempotencyKey { get; private set; }
        public Guid CorrelationId { get; private set; }
        public byte[] RowVersion { get; private set; } = default!;
        private IndexJob() : base(IndexJobId.New()) { } //EF Core
        protected IndexJob(IndexJobId id) : base(id)
        {
        }

        public static IndexJob Create(
            Guid sourceId,
            IndexJobType type,
            Guid idempotencyKey,
            Guid correlationId,
            Guid? externalOperationId = null,
            IndexJobStatus status = IndexJobStatus.Pending)
        {
            var now = DateTimeOffset.UtcNow;

            return new IndexJob(IndexJobId.New())
            {
                SourceId = sourceId,
                Type = type,
                Status = status,
                CreatedAt = now,
                StartedAt = status == IndexJobStatus.InProgress ? now : default,
                CompletedAt = default,
                AttemptCount = 0,
                LastError = string.Empty,
                ExternalOperationId = externalOperationId ?? Guid.NewGuid(),
                IdempotencyKey = idempotencyKey,
                CorrelationId = correlationId
            };
        }

        public void MarkInProgress(DateTimeOffset now) 
        {
            if (Status != IndexJobStatus.Pending)
                throw new InvalidOperationException("Only pending job can be moved to InProgress");

            Status = IndexJobStatus.InProgress;
            StartedAt = now;
            AttemptCount++;
            LastError = string.Empty;
        }

        public void MarkFailed(string error)
        {
            Status = IndexJobStatus.Failed;
            LastError = error;
        }
    }
}
