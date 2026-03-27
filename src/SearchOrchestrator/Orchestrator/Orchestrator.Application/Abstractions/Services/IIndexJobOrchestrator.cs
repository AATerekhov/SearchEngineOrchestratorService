namespace Orchestrator.Application.Abstractions.Services
{
    public interface IIndexJobOrchestrator
    {
        Task InvokeAsynce(CancellationToken ct);
    }
}
