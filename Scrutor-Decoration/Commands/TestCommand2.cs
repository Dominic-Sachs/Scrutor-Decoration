namespace Scrutor_Decoration.Commands;

public sealed class TestCommand2 : Command<int>
{
    public TestCommand2(Context context, string text) : base(context)
    {
        Text = text;
    }

    public string Text { get; }
}