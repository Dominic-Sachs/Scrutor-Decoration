namespace Scrutor_Decoration.Commands;

public sealed class TestCommand : Command
{
    public TestCommand(Context context, string text) : base(context)
    {
        Text = text;
    }

    public string Text { get; }
}