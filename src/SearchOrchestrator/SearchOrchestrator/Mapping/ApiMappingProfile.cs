using AutoMapper;
using Orchestrator.Application.Commands.CreateIndexJob;
using Orchestrator.Application.Commands.CreateSource;
using Orchestrator.Domain.Aggregates;
using SearchOrchestrator.DTOs.IndexJobs;
using SearchOrchestrator.DTOs.Sources;

namespace SearchOrchestrator.Mapping
{
    public sealed class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<CreateSourceRequestDto, CreateSourceCommand>();
            CreateMap<CreateIndexJobRequestDto, CreateIndexJobCommand>()
                .ForCtorParam(nameof(CreateIndexJobCommand.IdempotencyKey), opt => opt.MapFrom(src => src.IdempotencyKey ?? Guid.NewGuid()))
                .ForCtorParam(nameof(CreateIndexJobCommand.CorrelationId), opt => opt.MapFrom(src => src.CorrelationId ?? Guid.NewGuid()));

            CreateMap<Source, SourceDto>()
                .ForCtorParam(nameof(SourceDto.Id), opt => opt.MapFrom(src => src.Id.Value))
                .ForCtorParam(nameof(SourceDto.Name), opt => opt.MapFrom(src => src.Name.Value))
                .ForCtorParam(nameof(SourceDto.Location), opt => opt.MapFrom(src => src.Lacation.Value));

            CreateMap<IndexJob, IndexJobDto>()
                .ForCtorParam(nameof(IndexJobDto.Id), opt => opt.MapFrom(src => src.Id.Value));
        }
    }
}
