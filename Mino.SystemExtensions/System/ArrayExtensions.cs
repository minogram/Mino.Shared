namespace System;

internal static class ArrayExtensions
{
    private static readonly Random random = new Random(Guid.NewGuid().GetHashCode());

    /// <summary>
    /// Type safe ForEach
    /// </summary>
    public static void ForEach<T>(this T[] array, Action<T> action) => Array.ForEach(array, action);

    /// <summary>
    /// Get random item of array
    /// </summary>
    public static T GetRandom<T>(this T[] array) => array[random.Next(array.Length)];
}
