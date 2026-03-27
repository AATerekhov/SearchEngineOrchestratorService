using Orchestrator.Application.Abstractions;

namespace Orchestrator.Infrastructure.Persistence
{
    internal sealed class EfUnitOfWork(OrchestratorDbContext dbContext) : IUnitOfWork
    {
        public Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            return dbContext.SaveChangesAsync(ct);
        }
    }
}
