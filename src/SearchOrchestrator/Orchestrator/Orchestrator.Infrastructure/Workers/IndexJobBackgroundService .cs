using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orchestrator.Application.Abstractions.Services;

namespace Orchestrator.Infrastructure.Workers
{
    public sealed class IndexJobBackgroundService(
        IServiceScopeFactory scopeFactory,
        ILogger<IndexJobBackgroundService> logger) : BackgroundService
    {
        private static readonly TimeSpan Interval = TimeSpan.FromSeconds(5);

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = scopeFactory.CreateScope();
                    var orchestrator = scope.ServiceProvider.GetRequiredService<IIndexJobOrchestrator>();
                    await orchestrator.InvokeAsynce(stoppingToken);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error while processing outbox messages");
                }

                await Task.Delay(Interval, stoppingToken);
            }
        }
    }
}
