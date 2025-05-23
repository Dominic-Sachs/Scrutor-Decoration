namespace Scrutor_Decoration;

public interface ICommandDispatcher
{
    Task HandleAsync<TCommand>(TCommand command, CancellationToken token = default) where TCommand : Command;
    Task<TResult> HandleAsync<TCommand, TResult>(TCommand command, CancellationToken token = default) where TCommand : Command<TResult>;
}