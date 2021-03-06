using Slt.Art.Slt;
using Slt.Cli;

namespace SltTest.Art.Slt;

public class OutlineSltTest
{
    [Test]
    public void it_generates_outline()
    {
        //> Given
        var train = new OutlineSlt(new AnimationConfiguration());
        var expected = File.ReadAllText("Art/Fixtures/Outline.txt");

        //> When
        var result = train.ToString();

        //> Then
        Assert.That(
            string.Join("\n", result.Split("\n").Select(line => line.TrimEnd())).TrimEnd(),
            Is.EqualTo(expected.TrimEnd())
        );
    }
}
