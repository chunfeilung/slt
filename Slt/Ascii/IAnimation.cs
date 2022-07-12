using Slt.Cli.Consoles;

namespace Slt.Ascii;

/// <summary>
///     An animation that consists of 1 or more distinct frames
/// </summary>
public interface IAnimation
{
    /// <summary>
    ///     Show the current frame
    /// </summary>
    /// <param name="console">Console where the frame will be displayed</param>
    /// <returns>The current frame of this animation</returns>
    public Figure GetFrame(IConsole console);

    /// <summary>
    ///     Set the animation to a specific frame
    /// </summary>
    /// <param name="frame">Frame number</param>
    public void SetFrame(int frame);

    /// <summary>
    ///     Transition to the next frame of the animation
    /// </summary>
    public void Advance();

    /// <summary>
    ///     Check whether the animation has finished
    /// </summary>
    /// <returns>True if the animation has finished</returns>
    public bool HasFinished();
}
