namespace Scrutor_Decoration;

public interface ICommandDispatcher
{
    Task HandleAsync<TCommand>(TCommand command, CancellationToken token = default);
}