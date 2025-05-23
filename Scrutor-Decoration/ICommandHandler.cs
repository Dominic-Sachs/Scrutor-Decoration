namespace Scrutor_Decoration;

public interface ICommandHandlerAsync<in TCommand> where TCommand : Command
{
    Task HandleAsync(TCommand command, CancellationToken token);
}

public interface ICommandHandlerAsync<in TCommand, TResult> where TCommand : Command<TResult>
{
    Task<TResult> HandleAsync(TCommand command, CancellationToken token);
}