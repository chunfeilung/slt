using Slt.Ascii;
using Slt.Cli.Consoles;
using Slt.Util;

namespace Slt.Art.Etc;

public class Sparks : IAnimation
{
    private readonly Figure _figure;
    private int _frame;

    public Sparks(bool useColors = false)
    {
        _figure = new Figure(
            EmbeddedResource.ReadAllText("Slt.Art.Etc.Outline.Sparks.txt"),
            useColors ? EmbeddedResource.ReadAllText("Slt.Art.Etc.Outline.Colors.Sparks.txt") : ""
        );
    }

    public Figure GetFrame(IConsole console)
    {
        return _figure.Crop(9, 3, 0, _frame * 3);
    }

    public void SetFrame(int frame)
    {
        _frame = frame % 5 + 5;
    }

    public void Advance()
    {
        _frame = ++_frame % 5;
    }

    public bool HasFinished()
    {
        return false;
    }
}
