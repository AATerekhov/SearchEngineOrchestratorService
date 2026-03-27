using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orchestrator.Application.Abstractions;
using Orchestrator.Application.Abstractions.Services;
using Orchestrator.Application.Orchestration;
using Orchestrator.Domain.Repositories;
using Orchestrator.Infrastructure.Persistence;
using Orchestrator.Infrastructure.Persistence.Repositories;
using Orchestrator.Infrastructure.Workers;

namespace Orchestrator.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("OrchestratorDb")
                ?? "Data Source=search-orchestrator.db";

            services.AddDbContext<OrchestratorDbContext>(options =>
                options.UseSqlite(connectionString));

            services.AddScoped<ISourceRepository, EfSourceRepository>();
            services.AddScoped<IIndexJobRepository, EfIndexJobRepository>();
            services.AddScoped<IUnitOfWork, EfUnitOfWork>();
            services.AddScoped<IIndexJobOrchestrator, IndexJobOrchestrator>();

            services.AddHostedService<DatabaseInitializationHostedService>();
            services.AddHostedService<IndexJobBackgroundService>();

            return services;
        }
    }
}
