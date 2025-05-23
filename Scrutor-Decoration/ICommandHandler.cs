namespace Scrutor_Decoration;

public interface ICommandHandlerAsync<in TCommand>
{
    Task HandleAsync(TCommand command, CancellationToken token);
}