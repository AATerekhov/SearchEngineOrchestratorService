namespace Orchestrator.Application.DTOs.Client
{
    public static class SearchEnginesDto
    {
        //DTO для старта индексации
        public sealed record StartIndexingRequest
        {
            public Guid SourceId;
            public string SourceName = default!;
            public string SourceType = default!;
            public string Location = default!;
            public bool ForceReindex;
            public string CorrelationId = default!;
        }

        public sealed record StartIndexingResult
        {
            public string ExternalOperationId = default!;
            public string Status = default!;
        }

        //DTO статуса
        public sealed record IndexingStatusResult
        {
            public string ExternalOperationId = default!;
            public string Status = default!;
            public int ProcessedFiles;
            public int IndexedFiles;
            public int FailedFiles;
            public string? ErrorMessage;
        }

        //DTO для поиска
        public sealed record SearchRequestDto
        {
            public string Query = default!;
            public Guid? SourceId;
            public int Page = 1;
            public int PageSize = 20;
        }

        public sealed record SearchResultItemDto
        {
            public string DocumentId = default!;
            public string FileName = default!;
            public string Snippet = default!;
            public double Score;
        }

        public sealed record SearchResultDto
        {
            public int Total;
            public IReadOnlyCollection<SearchResultItemDto> Items = [];
        }

        public sealed record CancelIndexingResult
        {
            public string ExternalOperationId = default!; 
            public string Status = default!;
        }

    }
}
