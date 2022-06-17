using System.Reflection;

namespace Slt.Util;

public static class EmbeddedResource
{
    /// <summary>
    ///     Kind of like File.ReadAllText(), but for embedded resources
    /// </summary>
    /// <param name="name">Resource identifier, e.g. “Slt.Foo.Bar.Baz.txt”</param>
    /// <returns>Contents of the embedded resource</returns>
    public static string ReadAllText(string name)
    {
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream(name);
        using var reader = new StreamReader(stream!);
        return reader.ReadToEnd();
    }
}
