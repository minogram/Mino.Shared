namespace System;

public static class StringExtensions
{
    private static readonly char[] separator = { '\n', '\r' };

    public static string[] ToLines(this string source)
    {
        if (source == null || source == string.Empty)
            return Array.Empty<string>();

        return source.Split(separator, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
    }

    public static string Join(this string[] lines)
    {
        if (lines == null || lines.Length == 0) return null;
        return string.Join(Environment.NewLine, lines);
    }
}