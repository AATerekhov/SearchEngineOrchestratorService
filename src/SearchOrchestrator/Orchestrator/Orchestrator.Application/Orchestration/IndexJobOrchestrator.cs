using Microsoft.Extensions.Logging;
using Orchestrator.Application.Abstractions;
using Orchestrator.Application.Abstractions.Services;
using Orchestrator.Domain.Repositories;

namespace Orchestrator.Application.Orchestration
{
    public sealed class IndexJobOrchestrator(
        IIndexJobRepository indexJobRepository, 
        ISourceRepository sourceRepository, 
        IUnitOfWork unitOfWork,
        ILogger<IndexJobOrchestrator> logger) : IIndexJobOrchestrator
    {
        private const int BarchSize = 10;
        public async Task InvokeAsynce(CancellationToken ct) 
        {
            ct.ThrowIfCancellationRequested();
            //TODO: реализовать обработку IndexJobs => запуск на индексацию или запрос.

            //var indexJobs = indexJobRepository.

            await Task.CompletedTask;
        }
    }
}
