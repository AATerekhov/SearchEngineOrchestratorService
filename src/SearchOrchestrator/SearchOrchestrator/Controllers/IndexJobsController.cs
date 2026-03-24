using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Orchestrator.Application.Commands.CreateIndexJob;
using Orchestrator.Application.Queries.GetIndexJob;
using SearchOrchestrator.DTOs.IndexJobs;

namespace SearchOrchestrator.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public sealed class IndexJobsController(IMediator mediator, IMapper mapper) : ControllerBase
    {
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(IndexJobDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
        {
            var indexJob = await mediator.Send(new GetIndexJobQuery(id), ct);

            if (indexJob is null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<IndexJobDto>(indexJob));
        }

        [HttpPost]
        [ProducesResponseType(typeof(IndexJobDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateIndexJobRequestDto request, CancellationToken ct)
        {
            try
            {
                var command = mapper.Map<CreateIndexJobCommand>(request);
                var indexJob = await mediator.Send(command, ct);

                return CreatedAtAction(nameof(GetById), new { id = indexJob.Id.Value }, mapper.Map<IndexJobDto>(indexJob));
            }
            catch (InvalidOperationException exception)
            {
                return BadRequest(new ProblemDetails
                {
                    Title = "Unable to create index job",
                    Detail = exception.Message,
                    Status = StatusCodes.Status400BadRequest
                });
            }
        }
    }
}
