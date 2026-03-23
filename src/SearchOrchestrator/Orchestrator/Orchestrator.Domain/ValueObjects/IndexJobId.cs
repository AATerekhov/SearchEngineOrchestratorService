using Orchestrator.Domain.SharedKernel;

namespace Orchestrator.Domain.ValueObjects
{
    public sealed class IndexJobId : ValueObject
    {
        public Guid Value { get; }

        private IndexJobId(Guid value) => Value = value;

        public static IndexJobId New() => new(Guid.NewGuid());
        public static IndexJobId From(Guid value)
        {
            if (value == Guid.Empty) throw new ArgumentException("OrderId cannot be empty.", nameof(value));
            return new(value);
        }

        protected override IEnumerable<object?> GetEqualityComponents() { yield return Value; }

        public override string ToString() => Value.ToString();
    }
}
