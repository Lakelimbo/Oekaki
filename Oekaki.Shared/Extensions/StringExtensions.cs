using System.Text.RegularExpressions;

namespace Oekaki.Shared.Extensions;

public static partial class StringExtensions
{
    [GeneratedRegex(@"[^a-z0-9\s-]")]
    private static partial Regex InvalidCharactersRegex();

    [GeneratedRegex(@"\s+")]
    private static partial Regex MultipleSpacesRegex();

    [GeneratedRegex(@"\s")]
    private static partial Regex SpaceRegex();

    public static string Slugify(this string str)
    {
        str = str.ToLowerInvariant();
        str = InvalidCharactersRegex().Replace(str, "");
        str = MultipleSpacesRegex().Replace(str, " ").Trim();
        str = SpaceRegex().Replace(str, "-");

        return str;
    }
}
