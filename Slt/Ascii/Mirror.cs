namespace Slt.Ascii;

public static class Mirror
{
    /// <summary>
    ///     Generate a reversed version of a Figure, as if it was viewed in a mirror
    /// </summary>
    /// <param name="figure">A Figure that should be reversed.</param>
    /// <returns>A reversed version of the original Figure</returns>
    public static Figure Reflect(Figure figure)
    {
        return new Figure(
            string.Join(
                "\n",
                figure.Lines.Select(line => ReverseLine(line, figure.Width))
            ),
            string.Join(
                "\n",
                figure.ColorMap.Split("\n").Select(line => ReverseLine(line, figure.Width))
            )
        );
    }

    private static string ReverseLine(string line, int length)
    {
        return string.Join("",
                line
                    .PadRight(length, ' ')
                    .Reverse()
                    .Select(c =>
                    {
                        // Characters that have a “left” and “right” version
                        return c switch
                        {
                            '(' => ')',
                            ')' => '(',
                            '[' => ']',
                            ']' => '[',
                            '<' => '>',
                            '>' => '<',
                            '/' => '\\',
                            '\\' => '/',
                            _ => c
                        };
                    })
            )
            .TrimEnd();
    }
}
