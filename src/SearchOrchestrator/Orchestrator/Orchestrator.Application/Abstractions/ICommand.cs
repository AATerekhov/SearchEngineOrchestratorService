using MediatR;

namespace Orchestrator.Application.Abstractions;

public interface ICommand : IRequest { }

public interface ICommand<TResult> : IRequest<TResult> { }
