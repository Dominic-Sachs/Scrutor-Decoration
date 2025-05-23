namespace Scrutor_Decoration.Commands;

public sealed class TestCommand
{
    public TestCommand(string text)
    {
        Text = text;
    }

    public string Text { get; }
}