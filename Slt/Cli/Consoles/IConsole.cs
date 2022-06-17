using System.Drawing;
using Slt.Ascii;

namespace Slt.Cli.Consoles;

public interface IConsole
{
    /// <summary>
    ///     Retrieve the current size of the console window
    /// </summary>
    /// <returns>Current size of the console window</returns>
    public Size GetSize();

    /// <summary>
    ///     Play an animation until it finishes
    /// </summary>
    /// <param name="animation">Animation to be played</param>
    /// <param name="speed">Playback speed as a ratio of the default speed</param>
    public void Play(IAnimation animation, double speed);
}
