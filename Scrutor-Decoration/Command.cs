namespace Scrutor_Decoration;

public abstract class Command
{
    protected Command(Context context)
    {
        Context = context;
    }

    public Context Context { get; }
}

public abstract class Command<T> : Command
{
    protected Command(Context context) : base(context) { }
}