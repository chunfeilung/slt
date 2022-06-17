using System.CommandLine;
using Slt.Cli;

namespace SltTest.Cli;

public class SltCommandTest
{
    [Test]
    public void it_prints_debug_output()
    {
        //> Given
        var command = SltCommand.Build();

        var output = new StringWriter();
        Console.SetOut(output);

        var expected = File.ReadAllText("Art/Fixtures/Outline.txt");

        //> When
        command.Invoke(new[] { "--debug" });

        //> Then
        Assert.That(
            string.Join(
                "\n",
                output.ToString()
                    .Split("\n")
                    .Select(line => line.TrimEnd())
            ).TrimEnd(),
            Is.EqualTo(expected.TrimEnd())
        );
    }
}
