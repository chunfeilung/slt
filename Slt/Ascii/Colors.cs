using System.Drawing;
using Pastel;

namespace Slt.Ascii;

public static class Colors
{
    /// <summary>
    ///     Colorize text using colors that have been defined in a color map.
    /// </summary>
    /// <param name="text">The text to be colorized</param>
    /// <param name="colorMap">
    ///     String that represents the colors that are to be used for `text`. Its
    ///     size (i.e. width and height) should not exceed that of `text`.
    /// </param>
    /// <returns>`text`, with ANSI color codes inserted in the right places</returns>
    public static string Colorize(string text, string colorMap)
    {
        if (colorMap.Length == 0) return text;

        var result = text.Split("\n");

        // Wrap character sequences in `text` in ANSI color codes
        foreach (var (point, length, color) in Parse(colorMap))
        {
            var character = result[point.Y].Substring(point.X, length);
            result[point.Y] = result[point.Y]
                .Remove(point.X, length)
                .Insert(point.X, character.Pastel(color));
        }

        return string.Join("\n", result);
    }

    private static List<(Point, int, Color)> Parse(string input)
    {
        var result = new List<(Point, int, Color)>();
        var lines = input.Split("\n");

        for (var i = 0; i < lines.Length; i++)
        {
            var chars = lines[i].ToCharArray();

            for (var j = 0; j < chars.Length; j++)
            {
                // Treat spaces as transparent “pixels”
                if (chars[j] == ' ') continue;

                var color = ConvertCodeToColor(chars[j]);

                // Is same color as current sequence
                if (
                    result.Count > 0
                    &&
                    result[^1].Item1.Y == i
                    &&
                    result[^1].Item1.X + result[^1].Item2 == j
                    &&
                    result[^1].Item3.Equals(color)
                )
                {
                    var value = result[^1];
                    value.Item2++;
                    result[^1] = value;
                }
                else
                {
                    result.Add((new Point(j, i), 1, color));
                }
            }
        }

        result.Reverse();

        return result;
    }

    private static Color ConvertCodeToColor(char code)
    {
        return code switch
        {
            'B' => Color.MediumBlue,
            'b' => Color.LightSkyBlue,
            'D' => Color.DimGray,
            'G' => Color.Gray,
            'L' => Color.LightGray,
            'R' => Color.Firebrick,
            'Y' => Color.Gold,
            'W' => Color.White,
            _ => Color.Transparent
        };
    }
}
