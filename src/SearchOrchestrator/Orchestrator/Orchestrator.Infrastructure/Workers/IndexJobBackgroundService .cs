using Microsoft.Extensions.Hosting;

namespace Orchestrator.Infrastructure.Workers
{
    public sealed class IndexJobBackgroundService : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}
