using Orchestrator.Application.Abstractions;

namespace Orchestrator.Infrastructure.Persistence
{
    internal sealed class InMemoryUnitOfWork : IUnitOfWork
    {
        public Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            return Task.FromResult(1);
        }
    }
}
