using System.Collections.Generic;
using UnityEngine;

public static class ColectionExtension
{
    public static T RandomElement<T>(this IList<T> list)
    {
        return list[Random.Range(0, list.Count-1)];
    }

    public static T RandomElement<T>(this T[] array)
    {
        return array[Random.Range(0, array.Length)];
    }
}