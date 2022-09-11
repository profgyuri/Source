﻿using System.Security.Cryptography;

namespace Source.Extensions;

public static class ListExtensions
{
    /// <summary>
    /// Shuffles the collection.
    /// </summary>
    /// <typeparam name="T">The type of the collection.</typeparam>
    /// <param name="list">The collection to shuffle.</param>
    public static void Shuffle<T>(this IList<T> list)
    {
        var n = list.Count;

        while (n > 1)
        {
            int k;
            do
            {
                k = RandomNumberGenerator.GetInt32(n);
            } while (n == k);

            n--;

            (list[k], list[n]) = (list[n], list[k]);
        }
    }
    
    /// <summary>
    /// Adds the range of items to the collection.
    /// </summary>
    /// <typeparam name="T">The type of the collection.</typeparam>
    /// <param name="list">The collection to add the items to.</param>
    /// <param name="items">The items to add to the collection.</param>
    public static void AddRange<T>(this IList<T> list, IList<T> items)
    {
        for (int i = 0; i < items.Count; i++)
        {
            list.Add(items[i]);
        }
    }
}