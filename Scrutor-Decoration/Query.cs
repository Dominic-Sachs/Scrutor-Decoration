namespace Scrutor_Decoration;

public abstract class Query<T>
{
    protected Query(Context context)
    {
        Context = context;
    }

    public Context Context { get; }
}