namespace System.IO;

internal static class PathEx
{
    /// <summary>
    /// Combine된 path가 존재하지 않으면 새로 생성합니다.
    /// </summary>
    public static string EnsureDirectory(params string[] paths)
    {
        var directory = Path.Combine(paths);
        if (Directory.Exists(directory) == false)
            Directory.CreateDirectory(directory);
        return directory;
    }
}
