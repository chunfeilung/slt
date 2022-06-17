using Slt.Ascii;

namespace SltTest.Ascii;

public class ColorsTest
{
    [Test]
    public void it_colorizes_text()
    {
        //> Given
        const string text = "abc" + "\n" +
                            "def" + "\n" +
                            "ghi";
        const string colors = "BBB" + "\n" +
                              "BYY" + "\n" +
                              "Y Y";

        //> When
        var result = Colors.Colorize(text, colors);

        //> Then
        Assert.That(result, Is.EqualTo(
            "[38;2;0;0;205mabc[0m\n" +
            "[38;2;0;0;205md[0m[38;2;255;215;0mef[0m\n" +
            "[38;2;255;215;0mg[0mh[38;2;255;215;0mi[0m"
        ));
    }
}
