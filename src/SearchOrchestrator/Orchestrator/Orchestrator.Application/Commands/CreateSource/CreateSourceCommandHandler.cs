using MediatR;
using Orchestrator.Application.Abstractions;
using Orchestrator.Domain.Aggregates;
using Orchestrator.Domain.Repositories;
using Orchestrator.Domain.ValueObjects;

namespace Orchestrator.Application.Commands.CreateSource
{
    public sealed class CreateSourceCommandHandler(
        ISourceRepository sourceRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<CreateSourceCommand, Source>
    {
        public async Task<Source> Handle(CreateSourceCommand request, CancellationToken cancellationToken)
        {
            var source = Source.Create(
                SourceName.From(request.Name),
                request.Type,
                SourceLacation.From(request.Location),
                request.IsActive);

            await sourceRepository.AddAsync(source, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return source;
        }
    }
}
