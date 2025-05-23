namespace Scrutor_Decoration.Queries;

public sealed class HelloQuery
{
    public HelloQuery(string name)
    {
        Name = name;
    }

    public string Name { get; }
}