namespace System.Collections.Generic;

internal static class EnumerableExtensions
{
    /// <summary>
    /// Searches for an element that matches the conditions defined by the specified predicate,
    /// and returns the zero-based index of the first occurrence within the entire <see cref="IEnumerable{T}"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list">The list.</param>
    /// <param name="predicate">The predicate.</param>
    /// <returns>
    /// The zero-based index of the first occurrence of an element that matches the conditions defined by <paramref name="predicate"/>, if found; otherwise it'll throw.
    /// </returns>
    /// <example>
    /// <code>
    /// new[] { 3, 4, 5 }.FindIndex(4) returns 2.
    /// </code>
    /// </example>
    public static int FindIndex<T>(this IEnumerable<T> list, Func<T, bool> predicate)
    {
        int idx = 0;
        foreach (var item in list)
        {
            if (predicate(item))
                return idx;
            idx++;
        }
        return -1;
    }

    //public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
    //{
    //    foreach (var item in items)
    //    {
    //        action(item);
    //    }
    //}
}