using Orchestrator.Application.Abstractions.Contracts;
using Orchestrator.Application.Abstractions.Services;
using System.Collections.Concurrent;

namespace Orchestrator.Infrastructure.ExternalSearch
{
    public sealed class FakeSearchEngineClient(FakeSearchBehavior behavior = FakeSearchBehavior.Success) : ISearchEngineClient
    {
        private readonly ConcurrentDictionary<string, FakeOperationState> _operations = new();
        private readonly FakeSearchBehavior _behavior = behavior;

        public Task<StartIndexingResult> StartIndexingAsync(StartIndexingRequest request, CancellationToken ct)
        {
            string operationId = Guid.NewGuid().ToString("N");

            var state = new FakeOperationState
            {
                ExternalOperationId = operationId,
                SourceId = request.SourceId,
                SourceName = request.SourceName,
                Behavior = _behavior,
                Status = "Queued",
                PollCount = 0
            };
            _operations[operationId] = state;

            return Task.FromResult(new StartIndexingResult
            {
                ExternalOperationId = operationId,
                Status = "Accepted"
            });
        }
        public Task<IndexingStatusResult> GetIndexingStatusAsync(string externalOperationId, CancellationToken ct)
        {
            if (!_operations.TryGetValue(externalOperationId, out var state))
            {
                throw new InvalidOperationException($"Operation '{externalOperationId}' was not found.");
            }

            ct.ThrowIfCancellationRequested();
            state.PollCount++;

            switch (state.Behavior)
            {
                case FakeSearchBehavior.Timeout:
                    throw new TimeoutException("Fake timeout from Search Engine.");

                case FakeSearchBehavior.Fail:
                    state.Status = "Failed";
                    return Task.FromResult(new IndexingStatusResult()
                    {
                        ExternalOperationId = state.ExternalOperationId,
                        Status = state.Status,
                        ProcessedFiles = 12,
                        IndexedFiles = 0,
                        FailedFiles = 12,
                        ErrorMessage = "Fake external search engine failure."
                    });

                case FakeSearchBehavior.PartialSuccess:
                    if (state.PollCount == 1)
                    {
                        state.Status = "Running";
                        return Task.FromResult(new IndexingStatusResult
                        {
                            ExternalOperationId = state.ExternalOperationId,
                            Status = state.Status,
                            ProcessedFiles = 40,
                            IndexedFiles = 38,
                            FailedFiles = 2
                        });
                    }

                    state.Status = "PartiallySucceeded";
                    return Task.FromResult(new IndexingStatusResult
                    {
                        ExternalOperationId = state.ExternalOperationId,
                        Status = state.Status,
                        ProcessedFiles = 100,
                        IndexedFiles = 92,
                        FailedFiles = 8,
                        ErrorMessage = "Some files could not be parsed."
                    });

                case FakeSearchBehavior.Success:
                default:
                    if (state.PollCount == 1)
                    {
                        state.Status = "Running";
                        return Task.FromResult(new IndexingStatusResult
                        {
                            ExternalOperationId = state.ExternalOperationId,
                            Status = state.Status,
                            ProcessedFiles = 50,
                            IndexedFiles = 50,
                            FailedFiles = 0
                        });
                    }

                    state.Status = "Succeeded";
                    return Task.FromResult(new IndexingStatusResult
                    {
                        ExternalOperationId = state.ExternalOperationId,
                        Status = state.Status,
                        ProcessedFiles = 100,
                        IndexedFiles = 100,
                        FailedFiles = 0
                    });
            }
        }
        public Task<SearchResultDto> SearchAsync(SearchRequestDto request, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            if (string.IsNullOrWhiteSpace(request.Query))
            {
                return Task.FromResult(new SearchResultDto
                {
                    Total = 0,
                    Items = Array.Empty<SearchResultItemDto>()
                });
            }

            var items = new[]
            {
                new SearchResultItemDto
                {
                    DocumentId = "doc-1",
                    FileName = "contract-2026.pdf",
                    Snippet = $"Found match for '{request.Query}' in contract document.",
                    Score = 0.98
                },
                new SearchResultItemDto
                {
                    DocumentId = "doc-2",
                    FileName = "invoice-march.docx",
                    Snippet = $"Found match for '{request.Query}' in invoice document.",
                    Score = 0.87
                }
            };

            return Task.FromResult(new SearchResultDto
            {
                Total = items.Length,
                Items = items
            });
        }

        public Task<CancelIndexingResult> CancelIndexingAsync(string externalOperationId, CancellationToken ct)
        {
            throw new NotImplementedException();
        } 
    }
}
