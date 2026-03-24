using MediatR;
using Orchestrator.Application.Abstractions;
using Orchestrator.Domain.Aggregates;
using Orchestrator.Domain.Repositories;
using Orchestrator.Domain.ValueObjects;

namespace Orchestrator.Application.Commands.CreateIndexJob
{
    public sealed class CreateIndexJobCommandHandler(
        ISourceRepository sourceRepository,
        IIndexJobRepository indexJobRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<CreateIndexJobCommand, IndexJob>
    {
        public async Task<IndexJob> Handle(CreateIndexJobCommand request, CancellationToken cancellationToken)
        {
            var source = await sourceRepository.GetByIdAsync(SourceId.From(request.SourceId), cancellationToken);

            if (source is null)
            {
                throw new InvalidOperationException($"Source '{request.SourceId}' was not found.");
            }

            var indexJob = IndexJob.Create(
                request.SourceId,
                request.Type,
                request.IdempotencyKey,
                request.CorrelationId);

            await indexJobRepository.AddAsync(indexJob, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return indexJob;
        }
    }
}
