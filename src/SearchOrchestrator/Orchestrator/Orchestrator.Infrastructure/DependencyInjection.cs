using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orchestrator.Application.Abstractions;
using Orchestrator.Domain.Repositories;
using Orchestrator.Infrastructure.Persistence;
using Orchestrator.Infrastructure.Persistence.Repositories;

namespace Orchestrator.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<InMemoryStore>();
            services.AddSingleton<ISourceRepository, InMemorySourceRepository>();
            services.AddSingleton<IIndexJobRepository, InMemoryIndexJobRepository>();
            services.AddSingleton<IUnitOfWork, InMemoryUnitOfWork>();

            return services;
        }
    }
}
