using System;

namespace Helpers;

public static class RandomizerHelper

{
    private static readonly Random _random = new Random();

    public static T GetRandomNumber<T>(IList<T> items)
    {
        if (items == null || items.Count == 0)
            throw new ArgumentException("The list cannot be null or empty.");

        var rnd = new Random();
        int index = rnd.Next(items.Count);
        return items[index];
    }
}