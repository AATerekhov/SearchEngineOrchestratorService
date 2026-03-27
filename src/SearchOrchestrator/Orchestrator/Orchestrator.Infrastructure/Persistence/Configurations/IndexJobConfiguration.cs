using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orchestrator.Domain.Aggregates;
using Orchestrator.Domain.ValueObjects;

namespace Orchestrator.Infrastructure.Persistence.Configurations
{
    internal sealed class IndexJobConfiguration : IEntityTypeConfiguration<IndexJob>
    {
        public void Configure(EntityTypeBuilder<IndexJob> builder)
        {
            builder.ToTable("index_jobs");

            builder.HasKey(indexJob => indexJob.Id);

            builder.Property(indexJob => indexJob.Id)
                .HasConversion(
                    id => id.Value,
                    value => IndexJobId.From(value))
                .ValueGeneratedNever();

            builder.Property(indexJob => indexJob.SourceId)
                .IsRequired();

            builder.Property(indexJob => indexJob.Type)
                .HasConversion<int>()
                .IsRequired();

            builder.Property(indexJob => indexJob.Status)
                .HasConversion<int>()
                .IsRequired();

            builder.Property(indexJob => indexJob.CreatedAt)
                .IsRequired();

            builder.Property(indexJob => indexJob.StartedAt)
                .IsRequired();

            builder.Property(indexJob => indexJob.CompletedAt)
                .IsRequired();

            builder.Property(indexJob => indexJob.AttemptCount)
                .IsRequired();

            builder.Property(indexJob => indexJob.LastError)
                .HasMaxLength(4000)
                .IsRequired();

            builder.Property(indexJob => indexJob.ExternalOperationId)
                .IsRequired();

            builder.Property(indexJob => indexJob.IdempotencyKey)
                .IsRequired();

            builder.Property(indexJob => indexJob.CorrelationId)
                .IsRequired();

            builder.Property(indexJob => indexJob.RowVersion)
                .IsRowVersion();

            builder.HasIndex(indexJob => indexJob.Status);
            builder.HasIndex(indexJob => indexJob.SourceId);

            builder.Ignore(indexJob => indexJob.DomainEvents);
        }
    }
}
