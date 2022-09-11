using System.Security.Cryptography;

namespace Source.Extensions;

public static class IEnumerableExtensions
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
}