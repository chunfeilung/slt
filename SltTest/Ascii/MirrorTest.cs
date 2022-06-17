using Slt.Ascii;

namespace SltTest.Ascii;

public sealed class MirrorTest
{
    [Test]
    public void it_reverses_text()
    {
        //> Given
        const string originalText = @" \>)]" + "\n" +
                                    @"    abc" + "\n" +
                                    @"[(</";
        var art = new Figure(originalText);

        //> When
        var result = Mirror.Reflect(art);

        //> Then
        Assert.Multiple(() =>
        {
            Assert.That(result.ToString(), Is.EqualTo(
                @"  [(</" + "\n" +
                @"cba" + "\n" +
                @"   \>)]"
            ));
            Assert.That(art.ToString(), Is.EqualTo(originalText));
        });
    }
}
