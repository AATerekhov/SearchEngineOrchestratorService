using MediatR;

namespace Orchestrator.Application.Abstractions;

public interface IQuery<TResult> : IRequest<TResult> { }
