namespace Budgethold.Shared.Abstractions.Kernel.GlobalRegexs;

using System.Text.RegularExpressions;

public static partial class GlobalRegex
{
    private static readonly Regex _regex = MyRegex();

    [GeneratedRegex("^[a-zA-ZäöüßÄÖÜąćęłńóśźżĄĆĘŁŃÓŚŹŻ -.]+$", RegexOptions.Compiled)]
    private static partial Regex MyRegex();

    public static bool DoesMatchRegex(string value) => !_regex.IsMatch(value);
}
