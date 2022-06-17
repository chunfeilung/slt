using Slt.Ascii;
using Slt.Cli.Consoles;

namespace SltTest.Cli.Consoles;

public class InteractiveConsoleTest
{
    [Test]
    public void it_plays_animations()
    {
        //> Given
        var console = new InteractiveConsole(4, 1);
        var animation = new NotActuallyATrain();

        var output = new StringWriter();
        Console.SetOut(output);

        //> When
        console.Play(animation, 1_000);

        //> Then
        Assert.That(output.ToString(), Is.EqualTo(
            "    " +
            "   S" +
            "  Sp" +
            " Spr" +
            "Spri" +
            "prin" +
            "rint" +
            "inte" +
            "nter" +
            "ter " +
            "er  " +
            "r   " +
            "    "
        ));
    }

    private class NotActuallyATrain : IAnimation
    {
        private int _frame;

        public string GetFrame(IConsole console)
        {
            return new Figure("Sprinter").Crop(
                console.GetSize().Width,
                console.GetSize().Height,
                _frame,
                0
            ).Draw();
        }

        public void SetFrame(int frame)
        {
            _frame = frame;
        }

        public void Advance()
        {
            _frame++;
        }

        public bool HasFinished()
        {
            return _frame > "Sprinter".Length;
        }
    }
}
