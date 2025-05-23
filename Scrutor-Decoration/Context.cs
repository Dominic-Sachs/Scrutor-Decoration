namespace Scrutor_Decoration;

public sealed class Context
{
    public Context(Guid userId)
    {
        UserId = userId;
    }

    public Guid UserId { get; }
}