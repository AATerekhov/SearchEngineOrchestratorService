using MediatR;
using Orchestrator.Domain.Aggregates;
using Orchestrator.Domain.Repositories;
using Orchestrator.Domain.ValueObjects;

namespace Orchestrator.Application.Queries.GetIndexJob
{
    public sealed class GetIndexJobQueryHandler(IIndexJobRepository indexJobRepository)
        : IRequestHandler<GetIndexJobQuery, IndexJob?>
    {
        public Task<IndexJob?> Handle(GetIndexJobQuery request, CancellationToken cancellationToken)
        {
            return indexJobRepository.GetByIdAsync(IndexJobId.From(request.Id), cancellationToken);
        }
    }
}
