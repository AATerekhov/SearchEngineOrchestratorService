using static Orchestrator.Application.DTOs.Client.SearchEnginesDto;

namespace Orchestrator.Application.Abstractions
{
    public interface ISearchEngineClient
    {
        Task<StartIndexingResult> StartIndexingAsync(StartIndexingRequest request, CancellationToken ct);
        Task<IndexingStatusResult> GetIndexingStatusAsync(string externalOperationId, CancellationToken ct);
        Task<SearchResultDto> SearchAsync(SearchRequestDto request, CancellationToken ct);
        Task<CancelIndexingResult> CancelIndexingAsync(string externalOperationId, CancellationToken ct);
    }
}
