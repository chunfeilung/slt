using System.Drawing;
using Slt.Ascii;

namespace SltTest.Ascii;

public sealed class FigureTest
{
    [Test]
    public void figure_is_serialised_back_to_original_string()
    {
        //> Given
        const string text = @"
            ____
            |DD|____T_
            |_ |_____|<
              @-@-@-oo\
        ";
        var figure = new Figure(text);

        //> When
        var result = figure.ToString();

        //> Then
        Assert.That(result, Is.EqualTo(text));
    }

    [Test]
    public void width_and_height_are_computed_for_figure()
    {
        //> Given
        var figure = new Figure(
            " aaa\n" +
            "bbb\n" +
            " cc"
        );

        //> When
        var width = figure.Width;
        var height = figure.Height;

        //> Then
        Assert.Multiple(() =>
        {
            Assert.That(width, Is.EqualTo(4));
            Assert.That(height, Is.EqualTo(3));
        });
    }

    [Test]
    public void objects_can_be_added_to_figure()
    {
        //> Given
        var figure = new Figure(
            "\n" +
            "  00000\n" +
            "  00000\n" +
            "  00000"
        );

        //> When
        var result = figure.AddAt(new Figure(
            "11111\n" +
            "1   1\n" +
            "11111"
        ), new Point(5, 2));

        //> Then
        Assert.That(result.ToString(), Is.EqualTo(
            "          \n" +
            "  00000   \n" +
            "  00011111\n" +
            "  00010  1\n" +
            "     11111"
        ));
    }

    [Test]
    public void figure_is_centered_vertically_with_larger_viewport_height()
    {
        //> Given
        var figure = new Figure("Railrunner");

        //> When
        var result = figure.Crop(10, 5, 0, 0);

        //> Then
        Assert.That(result.ToString(), Is.EqualTo(
            @"          " + "\n" +
            @"          " + "\n" +
            @"Railrunner"
        ));
    }

    [Test]
    public void figure_is_cropped_with_small_viewport_width()
    {
        //> Given
        var figure = new Figure("Railrunner");

        //> When
        var result = figure.Crop(4, 1, 0, 0);

        //> Then
        Assert.That(result.ToString(), Is.EqualTo("Rail"));
    }

    [Test]
    public void figure_is_cropped_with_small_viewport_height()
    {
        //> Given
        var figure = new Figure(
            @"Aap" + "\n" +
            @"Noot" + "\n" +
            @"Mies"
        );

        //> When
        var result = figure.Crop(4, 1, 0, 0);

        //> Then
        Assert.That(result.ToString(), Is.EqualTo("Aap "));
    }

    [Test]
    public void figure_is_cropped_with_positive_offset()
    {
        //> Given
        var figure = new Figure(
            @"Aap" + "\n" +
            @"Noot" + "\n" +
            @"Mies"
        );

        //> When
        var result = figure.Crop(4, 1, 1, 1);

        //> Then
        Assert.That(result.ToString(), Is.EqualTo("oot "));
    }

    [Test]
    public void figure_is_padded_with_negative_offset()
    {
        //> Given
        var figure = new Figure(
            @"Aap" + "\n" +
            @"Noot" + "\n" +
            @"Mies"
        );

        //> When
        var result = figure.Crop(5, 4, -1, -1);

        //> Then
        Assert.That(result.ToString(), Is.EqualTo(
            @"     " + "\n" +
            @" Aap " + "\n" +
            @" Noot" + "\n" +
            @" Mies"
        ));
    }
}
