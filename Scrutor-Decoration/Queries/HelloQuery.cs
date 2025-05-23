namespace Scrutor_Decoration.Queries;

public sealed class HelloQuery : Query<string>
{
    public HelloQuery(Context context, string name) : base(context)
    {
        Name = name;
    }

    public string Name { get; }
}