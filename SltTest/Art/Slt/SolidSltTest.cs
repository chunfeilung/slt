using Slt.Art.Slt;
using Slt.Cli;

namespace SltTest.Art.Slt;

public class SolidSltTest
{
    [Test]
    public void it_generates_train()
    {
        //> Given
        var train = new SolidSlt(new AnimationConfiguration());
        var expected = File.ReadAllText("Art/Fixtures/Solid.txt");

        //> When
        var result = train.ToString();

        //> Then
        Assert.That(
            string.Join("\n", result.Split("\n").Select(line => line.TrimEnd())).TrimEnd(),
            Is.EqualTo(expected.TrimEnd())
        );
    }
}
