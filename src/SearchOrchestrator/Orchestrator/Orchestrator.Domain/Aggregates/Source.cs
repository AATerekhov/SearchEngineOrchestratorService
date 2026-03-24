using Orchestrator.Domain.Enums;
using Orchestrator.Domain.SharedKernel;
using Orchestrator.Domain.ValueObjects;

namespace Orchestrator.Domain.Aggregates
{
    public class Source : AggregateRoot<SourceId>
    {
        public SourceName Name { get; set; } = default!;
        public SourceType Type { get; private set; }
        public SourceLacation Lacation { get; set; } = default!;
        public DateTime LastIndexedAt { get; private set; }
        public bool IsActive { get; private set; }
        private Source() : base(SourceId.New()) { } //EF Core
        protected Source(SourceId id) : base(id)
        {
        }

        public static Source Create(
            SourceName name,
            SourceType type,
            SourceLacation location,
            bool isActive = true,
            DateTime? lastIndexedAt = null)
        {
            return new Source(SourceId.New())
            {
                Name = name,
                Type = type,
                Lacation = location,
                IsActive = isActive,
                LastIndexedAt = lastIndexedAt ?? DateTime.UtcNow
            };
        }
    }
}
