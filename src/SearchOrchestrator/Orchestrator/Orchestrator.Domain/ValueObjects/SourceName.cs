using Orchestrator.Domain.SharedKernel;

namespace Orchestrator.Domain.ValueObjects
{
    public sealed class SourceName : ValueObject
    {
        public string Value { get; }

        private SourceName(string value) => Value = value;

        public static SourceName From(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("SourceName cannot be empty.", nameof(value));
            return new(value);
        }

        protected override IEnumerable<object?> GetEqualityComponents() { yield return Value; }

        public override string ToString() => Value;
    }
}
