namespace System.Collections.Generic;

internal static class IListExtensions
{
    public static void AddRange<T>(this ICollection<T> list, IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            list.Add(item);
        }
    }

    //public static void AddRange<T>(this ICollection<T> list, params T[] items)
    //{
    //    foreach (var item in items)
    //    {
    //        list.Add(item);
    //    }
    //}
}