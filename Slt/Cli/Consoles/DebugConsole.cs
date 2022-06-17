using System.Drawing;
using Slt.Ascii;

namespace Slt.Cli.Consoles;

/// <summary>
///     A special type of console that prints out a static version of a complete
///     (uncropped) drawing
/// </summary>
public sealed class DebugConsole : IConsole
{
    public Size GetSize()
    {
        return new Size(Console.WindowWidth, Console.WindowHeight);
    }

    public void Play(IAnimation animation, double speed)
    {
        Console.Clear();
        Console.Write(animation.ToString());
    }
}
