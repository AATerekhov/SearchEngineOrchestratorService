using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orchestrator.Domain.Aggregates;
using Orchestrator.Domain.ValueObjects;

namespace Orchestrator.Infrastructure.Persistence.Configurations
{
    internal sealed class SourceConfiguration : IEntityTypeConfiguration<Source>
    {
        public void Configure(EntityTypeBuilder<Source> builder)
        {
            builder.ToTable("sources");

            builder.HasKey(source => source.Id);

            builder.Property(source => source.Id)
                .HasConversion(
                    id => id.Value,
                    value => SourceId.From(value))
                .ValueGeneratedNever();

            builder.Property(source => source.Name)
                .HasConversion(
                    name => name.Value,
                    value => SourceName.From(value))
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(source => source.Type)
                .HasConversion<int>()
                .IsRequired();

            builder.Property(source => source.Lacation)
                .HasConversion(
                    location => location.Value,
                    value => SourceLacation.From(value))
                .HasMaxLength(1024)
                .IsRequired();

            builder.Property(source => source.LastIndexedAt)
                .IsRequired();

            builder.Property(source => source.IsActive)
                .IsRequired();

            builder.Ignore(source => source.DomainEvents);
        }
    }
}
