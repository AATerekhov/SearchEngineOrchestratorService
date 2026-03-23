using Orchestrator.Domain.SharedKernel;

namespace Orchestrator.Domain.ValueObjects
{
    public sealed class SourceId : ValueObject
    {
        public Guid Value { get; }

        private SourceId(Guid value) => Value = value;

        public static SourceId New() => new(Guid.NewGuid());
        public static SourceId From(Guid value)
        {
            if (value == Guid.Empty) throw new ArgumentException("SourceId cannot be empty.", nameof(value));
            return new(value);
        }

        protected override IEnumerable<object?> GetEqualityComponents() { yield return Value; }

        public override string ToString() => Value.ToString();
    }
}
