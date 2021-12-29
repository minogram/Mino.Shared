﻿using System.Collections.Generic;

namespace System.Linq;

internal static class LinqExtensions
{
    /// <summary>
    /// Immediately executes the given action on each element in the source sequence.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the sequence</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="action">The action to execute on each element</param>

    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (action == null) throw new ArgumentNullException(nameof(action));

        foreach (var element in source)
            action(element);
    }

    /// <summary>
    /// Immediately executes the given action on each element in the source sequence.
    /// Each element's index is used in the logic of the action.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the sequence</typeparam>
    /// <param name="source">The sequence of elements</param>
    /// <param name="action">The action to execute on each element; the second parameter
    /// of the action represents the index of the source element.</param>

    public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (action == null) throw new ArgumentNullException(nameof(action));

        var index = 0;
        foreach (var element in source)
            action(element, index++);
    }

    /// <summary>
    /// Returns a sequence of <see cref="KeyValuePair{TKey,TValue}"/>
    /// where the key is the zero-based index of the value in the source
    /// sequence.
    /// </summary>
    /// <typeparam name="TSource">Type of elements in <paramref name="source"/> sequence.</typeparam>
    /// <param name="source">The source sequence.</param>
    /// <returns>A sequence of <see cref="KeyValuePair{TKey,TValue}"/>.</returns>
    /// <remarks>This operator uses deferred execution and streams its
    /// results.</remarks>
    public static IEnumerable<KeyValuePair<int, TSource>> Index<TSource>(this IEnumerable<TSource> source)
    {
        return source.Index(0);
    }

    /// <summary>
    /// Returns a sequence of <see cref="KeyValuePair{TKey,TValue}"/>
    /// where the key is the index of the value in the source sequence.
    /// An additional parameter specifies the starting index.
    /// </summary>
    /// <typeparam name="TSource">Type of elements in <paramref name="source"/> sequence.</typeparam>
    /// <param name="source">The source sequence.</param>
    /// <param name="startIndex"></param>
    /// <returns>A sequence of <see cref="KeyValuePair{TKey,TValue}"/>.</returns>
    /// <remarks>This operator uses deferred execution and streams its
    /// results.</remarks>
    public static IEnumerable<KeyValuePair<int, TSource>> Index<TSource>(this IEnumerable<TSource> source, int startIndex)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        return source.Select((item, index) => new KeyValuePair<int, TSource>(startIndex + index, item));
    }
}
