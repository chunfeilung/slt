using System.Drawing;

namespace Slt.Ascii;

/// <summary>
///     A Figure is an ASCII art drawing that can be arbitarily cropped and combined
///     with other Figures.
/// </summary>
public readonly struct Figure
{
    public readonly List<string> Lines;
    public readonly string ColorMap;

    public Figure() : this("")
    {
    }

    public Figure(string art, string colorMap = "") : this(art.Split("\n"), colorMap)
    {
    }

    private Figure(IEnumerable<string> art, string colorMap = "")
    {
        Lines = art.ToList();
        ColorMap = colorMap;
    }

    /// <summary>
    ///     Width of the Figure, in number of characters
    /// </summary>
    public int Width => Lines.Select(line => line.Length).Max();

    /// <summary>
    ///     Height of the Figure, in number of lines
    /// </summary>
    public int Height => Lines.Count;

    /// <summary>
    ///     Add the other Figure to the current Figure at the given point.
    /// </summary>
    /// <param name="other">The other Figure that should be added to this Figure</param>
    /// <param name="point">Top-left coordinate of the point where the other Figure will be placed</param>
    /// <returns>A new Figure that includes both the current and other Figure</returns>
    public Figure AddAt(Figure other, Point point)
    {
        var result = EnlargeCanvas(
            point.X + other.Width,
            point.Y + other.Height
        );

        return new Figure(
            result.Select((line, idx) =>
            {
                if (idx < point.Y || idx >= point.Y + other.Height) return line;

                return PatchLine(line, other.Lines[idx - point.Y], point.X);
            }),
            ColorMap.Length == 0 && other.ColorMap.Length == 0
                ? ""
                : new Figure(ColorMap).AddAt(new Figure(other.ColorMap), point).ToString()
        );
    }

    /// <summary>
    ///     Increase the size of the drawing canvas for the Figure by “allocating”
    ///     space for previously non-existing characters.
    /// </summary>
    /// <param name="newWidth">New width of the drawing canvas</param>
    /// <param name="newHeight">New height of the drawing canvas</param>
    /// <returns>The newly enlarged canvas</returns>
    private IEnumerable<string> EnlargeCanvas(int newWidth, int newHeight)
    {
        var result = Lines;

        if (newHeight > Height)
            result = result
                .Concat(Enumerable.Repeat("", newHeight - Height))
                .ToList();

        if (newWidth > Width)
            result = result
                .Select(line => line.PadRight(newWidth, ' '))
                .ToList();

        return result;
    }

    private static string PatchLine(string line, string patch, int idx)
    {
        // Some characters may have been inadvertently overwritten by ‘pixels’
        // that are supposed to be transparent
        var patchedLine = line
            .Remove(idx, patch.Length)
            .Insert(idx, patch)
            .ToCharArray();

        // So we’ll restore them here
        for (var i = 0; i < line.Length; i++)
            if (patchedLine[i] == ' ' && line[i] != ' ')
                patchedLine[i] = line[i];

        return string.Join("", patchedLine);
    }

    /// <summary>
    ///     Create a new cropped version that only shows part of this Figure.
    /// </summary>
    /// <param name="width">Width of the resulting crop, in a positive number of characters</param>
    /// <param name="height">Height of the resulting crop, in a positive number of lines</param>
    /// <param name="x">Start the crop from the nth char, where n can be any integer</param>
    /// <param name="y">Start the crop from the nth line, where n can be any integer</param>
    /// <returns>A cropped copy of this Figure</returns>
    public Figure Crop(int width, int height, int x, int y)
    {
        IEnumerable<string> result = Lines;

        result = x switch
        {
            < 0 => result.Select(line => string.Join("", Enumerable.Repeat(" ", -x)) + line),
            > 0 => result.Select(line => line[Math.Min(x, line.Length)..]),
            _ => result
        };

        result = y switch
        {
            < 0 => Enumerable.Repeat("", -y).Concat(result),
            > 0 => result.Skip(y),
            _ => result
        };

        if (height < Height) result = result.Take(height);

        if (height > Height) result = Enumerable.Repeat("", (height - Height) / 2).Concat(result);

        if (width < Width)
            result = result.Select(line =>
            {
                var length = Math.Min(width, line.Length);
                return line[..length];
            });

        result = result.Select(line => line.PadRight(width, ' '));

        return new Figure(
            result,
            ColorMap.Length == 0
                ? ""
                : new Figure(ColorMap).Crop(width, height, x, y).ToString()
        );
    }

    /// <summary>
    ///     Generates a drawable string for this Figure.
    /// </summary>
    /// <returns>
    ///     A string representation of this figure, with ANSI color codes
    ///     if a color map is present.
    /// </returns>
    public string Draw()
    {
        return Colors.Colorize(string.Join("\n", Lines), ColorMap);
    }

    public override string ToString()
    {
        return string.Join("\n", Lines);
    }
}
