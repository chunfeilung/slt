using System.Drawing;
using Slt.Ascii;

namespace Slt.Cli.Consoles;

public sealed class InteractiveConsole : IConsole
{
    private const int DefaultDelay = 20;
    private readonly int? _height;
    private readonly int? _width;

    public InteractiveConsole(int width, int height)
    {
        _width = width;
        _height = height;
    }

    public InteractiveConsole()
    {
    }

    public Size GetSize()
    {
        return new Size(
            _width ?? Console.WindowWidth,
            _height ?? Console.WindowHeight
        );
    }

    public void Play(IAnimation animation, double speed)
    {
        // Prevents program termination using Ctrl+C
        Console.TreatControlCAsInput = true;
        // Hides "teleporting" cell after last character
        Console.CursorVisible = false;

        Console.Clear();
        animation.SetFrame(-(_width ?? Console.WindowWidth));

        do
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(animation.GetFrame(this).Draw());
            animation.Advance();
            Thread.Sleep((int)(DefaultDelay / speed));
        } while (!animation.HasFinished());

        Console.Clear();
        Console.CursorVisible = true;
    }
}
