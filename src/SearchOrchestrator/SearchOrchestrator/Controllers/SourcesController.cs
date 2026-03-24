using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Orchestrator.Application.Commands.CreateSource;
using SearchOrchestrator.DTOs.Sources;

namespace SearchOrchestrator.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public sealed class SourcesController(IMediator mediator, IMapper mapper) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(SourceDto), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateSourceRequestDto request, CancellationToken ct)
        {
            var command = mapper.Map<CreateSourceCommand>(request);
            var source = await mediator.Send(command, ct);
            var response = mapper.Map<SourceDto>(source);

            return CreatedAtAction(nameof(Create), new { id = response.Id }, response);
        }
    }
}
