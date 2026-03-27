using Microsoft.EntityFrameworkCore;
using Orchestrator.Domain.Aggregates;
using Orchestrator.Domain.Enums;
using Orchestrator.Domain.Repositories;
using Orchestrator.Domain.ValueObjects;

namespace Orchestrator.Infrastructure.Persistence.Repositories
{
    internal sealed class EfIndexJobRepository(OrchestratorDbContext dbContext) : IIndexJobRepository
    {
        public Task AddAsync(IndexJob indexJob, CancellationToken ct = default)
        {
            return dbContext.IndexJobs.AddAsync(indexJob, ct).AsTask();
        }

        public async Task<IReadOnlyList<IndexJob>> ClaimPandingBatchAsync(int batchSize, DateTimeOffset now, CancellationToken ct = default)
        {
            var claimed = new List<IndexJob>();

            var condidates = await dbContext.IndexJobs
                .Where(x => x.Status == IndexJobStatus.Pending)
                .OrderBy(x => x.CreatedAt)
                .Take(batchSize)
                .ToListAsync(ct);

            foreach (var job in condidates) 
            {
                try
                {
                    job.MarkInProgress(now);
                    await dbContext.SaveChangesAsync(ct);
                    claimed.Add(job);
                }
                catch (DbUpdateConcurrencyException)
                {
                    dbContext.Entry(job).State = EntityState.Detached;
                }
            }
            return claimed;
        }

        public Task<IndexJob?> GetByIdAsync(IndexJobId id, CancellationToken ct = default)
        {
            return dbContext.IndexJobs
                .SingleOrDefaultAsync(indexJob => indexJob.Id == id, ct);
        }

        public async Task<IReadOnlyList<IndexJob>> GetPandingBatchAsync(int batchSize, CancellationToken ct = default)
        {
            return await dbContext.IndexJobs
                .Where(indexJob => indexJob.Status == IndexJobStatus.Pending)
                .OrderBy(indexJob => indexJob.CreatedAt)
                .Take(batchSize)
                .ToListAsync(ct);
        }
    }
}
